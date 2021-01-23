                    bulkCopy .BulkCopyTimeout = 0;
                    bulkCopy .ColumnMappings.Add(dt.Columns[0].ColumnName, "CLIENT_INPUT_MHS_ID");
                    bulkCopy .ColumnMappings.Add(dt.Columns[1].ColumnName, "CLIENT_INPUT_MHS_GUID");
                    bulkCopy .ColumnMappings.Add(dt.Columns[2].ColumnName, "ITEM");
                    bulkCopy .ColumnMappings.Add(dt.Columns[3].ColumnName, "ITEM_ID");
                    bulkCopy .ColumnMappings.Add(dt.Columns[4].ColumnName, "ITEM_NUMBER");
                    bulkCopy .ColumnMappings.Add(dt.Columns[5].ColumnName, "CATEGORY");
                    bulkCopy.DestinationTableName = "DestinationTableName";                   
                    bulkCopy.WriteToServer(dt); }
