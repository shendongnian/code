    foreach(Bar p in fooList.Where(a => a.Bars !=null).SelectMany(a => a.Bars.Where(b => b.BarID == barID)))
                {
                    if (p.Bazes == null)
                    {
                        p.Bazes = new List<Baz>();
                    }
                    p.Bazes.Add(bazID);
                }
