	var a = new object();
	var originalHashCodeA = a.GetHashCode();
	for (var i = 0; i < 10000; ++i)
		new object();
	var b = new object();
	var originalHashCodeB = b.GetHashCode();
	
	// Synchronous garbage collection (see http://stackoverflow.com/q/748777/87399)
	GC.Collect();
	GC.WaitForPendingFinalizers();
	GC.Collect();
	
	Console.WriteLine(a.GetHashCode() == originalHashCodeA);
	Console.WriteLine(b.GetHashCode() == originalHashCodeB);
