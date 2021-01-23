        public static IEnumerable<Result> Connect(this IEnumerable<Point> setA, IEnumerable<Point> setB) {
            return setA
                .Select(a => setB.Select(b => new Result { A = a, B = b, D = a.DistanceTo(b) }))
                .SelectMany(s => s)
                .OrderBy(s => s.D)
                .Reduce(new Result[] { }, (a,b) => a.A != b.A && a.B != b.B);
        }
