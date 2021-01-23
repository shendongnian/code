    LatestObj = randomEntity.Where(x => x.Id == z.Key.Id)
                                       .GroupBy(x => x.Id)
                                       .Select(gr => new {
                                            item1 = gr.Key,
                                            item2 = gr.Max(x => x.SomeInteger.Value)
                                       })
