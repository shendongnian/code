    var result = MyLines.SelectMany(l => new[] { 
                                       new { X = l.X1, Y = l.Y1 },
                                       new { X = l.X2, Y = l.Y2 }
                                    }, (l,p) => new { Point = p, Line = l })
                       .GroupBy(x => x.Point)
                       .ToDictionary(g => new _2DPoint { X = g.Key.X, Y = g.Key.Y },
                                     g => g.Select(x => x.Line).ToList());
