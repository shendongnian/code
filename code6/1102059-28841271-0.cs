                var categories = sortedData
                    .GroupBy(i => i.Make)
                    .Select(g => new
                    {
                        name = g.Key,
                        categories = sortedData
                            .Where(i2 => i2.Make == g.Key)
                            .Select(i2 => i2.InspectionCode)
                    });
