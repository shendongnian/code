    var result = from e in entities // where entities is in-memory list
                 group e by new { e.A, e.B, e.C } into g
                 select new Entity {
                    A = g.Key.A,
                    B = g.Key.B,
                    C = g.Key.C,
                    D = String.Join(",", g.Select(e => e.D))
                 };
