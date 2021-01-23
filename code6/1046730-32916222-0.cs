    DateTime d1l = DateTime.Now;
    long dl = d1l.ToBinary();
    DateTime d2l = DateTime.FromBinary(dl);
    
    DateTime d1u = DateTime.UtcNow;
    long du = d1u.ToBinary();
    DateTime d2u = DateTime.FromBinary(du);
    	
    Console.WriteLine("Local test passed: " + (d1l == d2l).ToString());
	Console.WriteLine("d2l kind: " + d2l.Kind.ToString());
	Console.WriteLine("Utc test passed: " + (d1u == d2u).ToString());
	Console.WriteLine("d2u kind: " + d2u.Kind.ToString());
