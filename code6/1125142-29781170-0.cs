    using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
                    {
                        sqlBulkCopy.BulkCopyTimeout = 600;
                        sqlBulkCopy.DestinationTableName = "daneProduktu";
                        sqlBulkCopy.ColumnMappings.Add("numerProduktu", "numerProduktu");
                        sqlBulkCopy.ColumnMappings.Add("numerSklepu", "numerSklepu");
                        sqlBulkCopy.ColumnMappings.Add("cena", "cena");
                        sqlBulkCopy.ColumnMappings.Add("pozycjaCeneo", "pozycjaCeneo");
                        sqlBulkCopy.WriteToServer(dt);
                    }
