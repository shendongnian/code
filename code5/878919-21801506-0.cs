	double[] x =
		// Read all lines inside an IEnumerable<string>
		File.ReadAllLines(@"E:\TestFile.txt")
		// Create a single string concatenating all lines with a space between them
		.Aggregate("", (current, newLine) => current + " " + newLine)
		// Create an array with the values in the string that were separated by spaces
		.Split(' ')
		// Remove all the empty values that can be due to multiple spaces
		.Where(s => !string.IsNullOrWhiteSpace(s))
		// Convert each string value into a double (Returning an IEnumerable<double>)
		.Select(s => double.Parse(s))
		// Convert the IEnumerable<double> to an array
		.ToArray();
