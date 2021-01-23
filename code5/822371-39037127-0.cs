                                int sourceColumnIndex = dtSource.Columns.IndexOf(destinationTable.Columns[i].ToString());//Once column matched get its index
                                bulkCopy.ColumnMappings.Add(dtSource.Columns[sourceColumnIndex].ToString(), dtSource.Columns[sourceColumnIndex].ToString());//give coluns name of source table rather then destination table o that it would avoid case sensitivity
                            }
                           
                        }
                        bulkCopy.WriteToServer(destinationTable);
                        bulkCopy.Close();
