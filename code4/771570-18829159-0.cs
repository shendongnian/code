	var input = "060201080808040602040909080909003583150369840500";
	// parse the input into a byte[]
	var inputBytes = Enumerable.Range(0, input.Length/2)
	                           .Select(i => input.Substring(i*2, 2))
	                           .Select(s => byte.Parse(s, NumberStyles.HexNumber))
	                           .ToArray();
	var hash = new SHA1CryptoServiceProvider().ComputeHash(inputBytes);
	var outputHexString = string.Join(" ", 
		hash.Select(b => b.ToString("X")).ToArray());
	Console.WriteLine(outputHexString);
