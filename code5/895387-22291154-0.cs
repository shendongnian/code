	var input = @"123vcvcv00191pololo";
	var array =
		input
			.ToCharArray()
			.Where(c => !Char.IsDigit(c))
			.Concat(
				input
					.ToCharArray()
					.Where(c => Char.IsDigit(c)))
			.ToArray();
	var output = new String(array);
	Console.Write(output);
	// vcvcvpololo12300191 
