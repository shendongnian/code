			string strTester = "AaaaAA";
			var results = System.Text.RegularExpressions.Regex.Matches(strTester,"(.*[A-Z]{1}.*){3,}");
			var occuranceCount = results.Count;
			if (occuranceCount >= 1 ) {
				Console.WriteLine("true");
			}
			else {
				Console.WriteLine("false");
			}
