    Map = entitys => entitys.Select(entity=> 
                                    new { Query = new object[]
                                            {
                                               entity.Name,
                                               new[]{"Value 1","Value 2"}[(int)entity.])
                                             }
                                        });
