    var LeftTable = new[]
            {
                new { A = 1, B=1, C=1 },
                new { A = 1, B=2, C=2 },
                new { A = 5, B=6, C=7 }
            }
            .ToList();
            var RightTable = new[]
            {
                new { A = 1, B=1, Z=5 },
                new { A = 1, B=2, Z=6 }
            }
            .ToList();
            var query = (from left in LeftTable
                         join right in RightTable
                            on new { left.A, left.B } equals new { right.A, right.B }
                            into JoinedList
                         from right in JoinedList.DefaultIfEmpty(new { A = 0, B = 0, Z = 0 })
                         group left by new
                         {
                             left.A,
                             left.B,
                             left.C,
                             right.Z
                         } into g
                         select g)
                        .ToList();
