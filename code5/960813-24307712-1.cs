    var result = Enumerable.Range(1, MaxA)
                    .SelectMany(
                        a => Enumerable.Range(a + 1, MaxB)
                            .SelectMany(
                                b => Enumerable.Range(b + 1, MaxC)
                                    .Select(c => new { a, b, c })))
