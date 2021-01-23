	Func<string, IEnumerable<int>, IEnumerable<string>> f = null;
	f =
		(t, ns) =>
		{
			if (ns.Any())
			{
				var n = ns.First();
				var i = System.Math.Min(n, t.Length);
				var t0 = t.Substring(0, i);
				var t1 = t.Substring(i);
				return new [] { t0.Trim(), }.Concat(f(t1, ns.Skip(1)));
			}
			else
				return new [] { t.Trim(), };
		};
