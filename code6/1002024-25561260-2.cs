	string stringData = "AAAB"; // {000000} {000000} {000000} {000001}
	byte[] byteData = Convert.FromBase64String(stringData); // {00000000}{00000000}{00000001}
	
	BitArray bitData = new BitArray(byteData.Reverse().ToArray()); // {000000000000000000000001}
	
	Console.WriteLine("byteData");
	for(var i=0; i < byteData.Length; i++){ //bitData.Length is 32
		var bitValue = byteData[i];
		Console.WriteLine("{0} {1}", i, bitValue);
	}
	
	Console.WriteLine();
	Console.WriteLine("bitData");
	for(var i=0; i < bitData.Length; i++){ //bitData.Length is 32
		var bitValue = bitData[i];
		Console.WriteLine("{0} {1}", i, bitValue);
	}
	
	
	Console.WriteLine();
	Console.WriteLine("reversed");
	var reversed = bitData.Cast<bool>().Reverse().ToArray();
	for(var i=0; i < reversed.Length; i++){ //bitData.Length is 32
		var bitValue = reversed[i];
		Console.WriteLine("{0} {1}", i, bitValue);
	}
