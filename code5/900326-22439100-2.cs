        public static IEnumerable<Result> Connect(this IEnumerable<Point> listA, IEnumerable<Point> listB) {
            return listA
                .Select(a => listB.Select(b => new Result { A = a, B = b, D = a.DistanceTo(b) }))
                .SelectMany(s => s).ToList()
                .OrderBy(s => s.D)
                .Reduce(new Result[] { }, (a,b) => a.A != b.A && a.B != b.B);
        }
