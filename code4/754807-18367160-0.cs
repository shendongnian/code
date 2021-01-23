    foreach(Bar p in fooList.SelectMany(a => a.Bars.Where(b => b.BarID == barID)))
                {
                    if (p.Bazes == null)
                    {
                        p.Bazes = new List<Baz>();
                    }
                    p.Bazes.Add(bazID);
                }
