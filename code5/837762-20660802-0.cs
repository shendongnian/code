    flatList.Groupby(i => i.FatherId)
            .Select(g => new Father{
                            id = g.Key,
                                 propertyF,
                                 children = g.Select( c => new Child() {
                                                               id = Children Id,
                                                                    prop1,
                                                                    prop2
                                                                }
                                                    )
                                              .ToList()
                                  }
                    )
            
          
