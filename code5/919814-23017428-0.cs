                System.Data.DataSet oDataSet = new System.Data.DataSet();
                oDataSet.ReadXmlSchema(strSchemaXml);
                oDataSet.ReadXml(strTableXml);
                if (oDataSet.Tables.Count > 0)
                {
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(oTargetDatabase.ConnectionString))
                    {
                        conn.Open();
                        System.Data.SqlClient.SqlTransaction oTran = conn.BeginTransaction();
                        System.Data.SqlClient.SqlBulkCopy oSqlBulkCopy
                            = new System.Data.SqlClient.SqlBulkCopy(conn, System.Data.SqlClient.SqlBulkCopyOptions.KeepIdentity, oTran);
                        oSqlBulkCopy.BulkCopyTimeout = 600; 
                        oSqlBulkCopy.BatchSize = 1000;
                        oSqlBulkCopy.DestinationTableName = strFullyQualifiedTableName; 
                        oSqlBulkCopy.NotifyAfter = 10000;
                        oSqlBulkCopy.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(oSqlBulkCopy_SqlRowsCopied);
                        foreach (System.Data.DataColumn ocol in oDataSet.Tables[0].Columns)
                        {
                            oSqlBulkCopy.ColumnMappings.Add(ocol.ColumnName, ocol.ColumnName);
                        }
                        oSqlBulkCopy.WriteToServer(oDataSet.Tables[0]);
                        oTran.Commit();
                        conn.Close();
                    }
                    System.Console.WriteLine("Wrote : " + oDataSet.Tables[0].Rows.Count.ToString() + " records ");
                }
