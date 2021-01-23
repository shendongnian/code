            string str = "The quick brown fox jumps over the lazy dog";
            Regex r = new Regex(@"(^|\s)+([^\s]+)");
            MatchCollection mc = r.Matches(str);                        
            for (int i = 0; i < mc.Count; i++)
            {
                System.Console.WriteLine(mc[i].Groups[2]);
            } 
