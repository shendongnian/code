    var result = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(r => r, StringComparer.InvariantCultureIgnoreCase)
                    .Where(grp => grp.Count() >= 10)
                    .Select(grp => new
                        {
                            Word = grp.Key,
                            Count = grp.Count()
                        });
