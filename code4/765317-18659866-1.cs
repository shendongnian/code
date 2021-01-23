	var comparer = new VersionComparer();
	Debug.Assert(comparer.Compare("2.C", "2.D") < 0);  // 2.C is older
	Debug.Assert(comparer.Compare("2.D", "2.D") == 0); // same
	Debug.Assert(comparer.Compare("2.E", "2.D") > 0);  // 2.E is newer
	Debug.Assert(comparer.Compare("3.C", "2.D") > 0);  // 3.C is newer
	Debug.Assert(comparer.Compare("0.A", "0.B") < 0);  // 0.A is older
