	static void CollectAll(ISet<String> remaining, IList<string> soFar, List<List<string>> all) {
		if (soFar.Count != 0) {
			all.Add(soFar.ToList());
		}
		foreach (var item in remaining.ToList()) {
			remaining.Remove(item);
			soFar.Add(item);
			CollectAll(remaining, soFar, all);
			soFar.Remove(item);
			remaining.Add(item);
		}
	}
