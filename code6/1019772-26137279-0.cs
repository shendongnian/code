    using (var bcp = new SqlBulkCopy(fhxm.Database.Connection.ConnectionString))
                                        {
                                        using (var creader = ObjectReader.Create(functionblock.connections, "step", "transition", "steptotrans", "functionblockId"))
                                        {
                                        SqlBulkCopyColumnMapping mapstep = new SqlBulkCopyColumnMapping("step", "step");
                                        SqlBulkCopyColumnMapping maptran = new SqlBulkCopyColumnMapping("transition", "transition");
                                        SqlBulkCopyColumnMapping mapstt = new SqlBulkCopyColumnMapping("steptotrans", "steptotrans");
                                        SqlBulkCopyColumnMapping mapfunc = new SqlBulkCopyColumnMapping("functionblockId", "functionblockId");
                                        bcp.ColumnMappings.Add(mapstep);
                                        bcp.ColumnMappings.Add(maptran);
                                        bcp.ColumnMappings.Add(mapstt);
                                        bcp.ColumnMappings.Add(mapfunc);
                                        
                                        bcp.DestinationTableName = "connections";
                                        bcp.WriteToServer(creader);
                                        }   } 
