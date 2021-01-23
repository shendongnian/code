			int StrCount = str1.Count(); // str1, str2, and str3 guaranteed to be equal in size and > 0.
			var RetStr = from i in Enumerable.Range(0, StrCount)
						 let sb1 = new StringBuilder(200)
						 select (sb1.Append(str1.ElementAt(i)).Append(' ').Append(str2.ElementAt(i)).Append(' ').Append(str3.ElementAt(i))).ToString();
			return RetStr.AsParallel().ToArray();
