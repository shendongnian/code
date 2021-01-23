            string test = "(anything)....bbbbbb....(anything)";
			Regex r = new Regex("b(?=b)");
			var s = new System.Diagnostics.Stopwatch();
			s.Start();
			int i=0; 
			int l=5000;
			for (;i<l;i++) {
				var result = r.Matches(test);
			}
			Console.WriteLine(s.ElapsedTicks.ToString());
			i = 0;
			string needle = "bb"; 
            int pos = 0;
			s.Reset();
			s.Start();
			for (;i<l;i++) {
				pos = 0;
                while((pos = test.IndexOf(needle, pos)) != -1)
                {
                    pos++;
                }
			}
			Console.WriteLine(s.ElapsedTicks.ToString());
