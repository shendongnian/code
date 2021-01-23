    Color[][] p = Enumerable.Range(0, Source.Width)
                            .Select(i => Enumerable.Range(0, Source.Height)
                                                   .Select(j => Source.GetPixel(i, j))
                                                   .ToArray())
                            .ToArray();
