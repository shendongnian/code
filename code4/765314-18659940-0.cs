    IList<PersonaGroup> listPersonasGroups = listPersonas
                                    .GroupBy(p => p.Lastname)
                                    .Select((pg, i) => new PersonaGroup {
                                                            Lastname = pg.Key,
                                                            Count = pg.Count(),
                                                            Index = i
                                    })
                                    .ToList();
