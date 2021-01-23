	var text = @"i have the car which is very fast. me is slow.";
	var length = 2;
	var first = true; // first word in the sentence
	var containsDot = false; // previous word contains a dot
	var result = text
					.Split(' ')
					.ToList()
					.Select (p => 
						{
							if (first)
							{
								p = FirstCharToUpper(p);
								first = false;
							}
							if (containsDot)
							{
								p = FirstCharToUpper(p);
								containsDot = false;
							}
							containsDot = p.Contains(".");
							if (p.Length > length)
							{
								return FirstCharToUpper(p);
							}
							return p;
						})
					.Aggregate ((h, t) => h + " " + t);
	Console.WriteLine(result);
