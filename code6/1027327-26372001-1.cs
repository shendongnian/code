    var artprices = art.GroupBy(c => c.Type)
                       .Select(c => new
                                    {
                                        ArtType = c.Key,
                                        MostExpensive = c.Max(x => x.Price)
                                    });
