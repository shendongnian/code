    var results = rows.GroupBy(row => new {row.FromBay, row.FromPanel, row.TagNo})
            .Select(x => new
                {
                    x.Key.TagNo,
                    x.Key.FromBay,
                    x.Key.FromPanel,
                    Devices =
                            rows.GroupBy(
                                row => new {row.FromBay, row.FromPanel, row.TagNo, row.FDevice})
                                .Where(f => f.Key.TagNo == x.Key.TagNo)
                                .Where(f => f.Key.FromBay == x.Key.FromBay)
                                .Where(f => f.Key.FromPanel == x.Key.FromPanel)
                                .Select(y => new
                                    {
                                        y.Key.FDevice,
                                        FRef =
                                                rows.Where(r => r.TagNo == y.Key.TagNo)
                                                    .Where(r => r.FromBay == y.Key.FromBay)
                                                    .Where(r => r.FromPanel == y.Key.FromPanel)
                                                    .Where(r => r.FDevice == y.Key.FDevice)
                                                    .Select(i => i.FRef)
                                                    .ToList()
                                    }).ToList()
                }).ToList();
