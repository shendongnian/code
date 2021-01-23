            string s = File.ReadAllText(@"D:\SampleXML.txt");
            Regex r = new Regex(@"start-student--(.+?)--end-student");
            MatchCollection mc = r.Matches(s);
            string[] c = new string[mc.Count];
            for (int i = 0; i < mc.Count; i++)
            {
                c[i] = mc[i].Groups[0].Value;
            }
            string result = string.Join("\n", c);
            Console.WriteLine(result);
