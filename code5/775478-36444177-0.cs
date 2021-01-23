    query.Select(zv => new {
                                    zv,
                                    rId = zv.this.Reintegraties.FirstOrDefault().Id
                                })
                                .Where(x => !db.Taken.Any(t => t.HoortBijEntiteitId == x.rId
                                                        && t.HoortBijEntiteitType == EntiteitType.Reintegratie
                                                        && t.Type == TaakType))
                                .Select(x => x.zv);
