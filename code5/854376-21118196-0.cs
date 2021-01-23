    var filtered = dataCollection.Where(obj => 
                        criteriaCollection.Any(cond => obj.GetType()
                                                          .GetProperty(cond.ColumnName)
                                                          .GetValue(obj)
                                                          .Equals(cond.ColumnValue)))
                                 .ToList();
