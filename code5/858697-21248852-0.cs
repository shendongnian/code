    var qu = list.Select(x =>
                            {
                                decimal? d;
                                try
                                {
                                    d = Convert.ToDecimal(x);
                                }
                                catch (FormatException)
                                {
                                    d = null;
                                }
                                return new { v = x, d, s = x.ToString() };
                            }).GroupBy(x => x.d.HasValue)
                              .Select(g =>
                                  g.Key
                                  ? g.OrderBy(x => x.d.Value).Select(x => x.v)
                                  : g.OrderBy(x => x.s).Select(x => x.v))
                              .SelectMany(x => x)
                              .ToList();
