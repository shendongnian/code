    var a = new Tuple<int, int>(1, 1);
    var b = new[] { a };
    var q = b.AsQueryable().Select(it=>A.Test(it.Item1));
    var q1 = b.AsQueryable().Select(it => Convert.ToInt32(it.Item1));
    var q2 = b.AsQueryable().Select(it => (float) it.Item1);
