            Dictionary<string, string> dict = new Dictionary<string,string>();
            Regex regex = new Regex(@"S?(\d{1,2})[x|e]?(\d{1,2})", RegexOptions.IgnoreCase);
            foreach (string file in path)
            {
                var match = regex.Match(file);
                if (match.Success)
                {
                    string key = "S" + match.Groups[1].Value.PadLeft(2, '0') + "E" + match.Groups[2].Value.PadLeft(2, '0');
                    if (dict.ContainsKey(key))
                    {
                        // .. already in there
                    }
                    else
                    {
                        dict[key] = file;
                    }
                }
            }
