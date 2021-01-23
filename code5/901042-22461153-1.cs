            var input = new List<string>
            {
                "Blue Code \n 03 ID \n 05 Example \n Sky is blue",
                "Green Code\n 01 ID\n 15",
                "038  038\n 0004  049.0\n 0006",
                "Test TestCode \n 99 \n Testing is fun"
            };
            var output = new List<List<string>>();
            foreach (var item in input)
            {
                var items = new List<string> {item.Split(' ')[0]};
                const string strRegex = @"(?<group>[a-zA-Z0-9\.]*\s*\n\s*[a-zA-Z0-9\.]*)";
                var myRegex = new Regex(strRegex, RegexOptions.None);
                var matchCollection = myRegex.Matches(item.Remove(0, item.Split(' ')[0].Length));
                
                for (var i = 0; i < 2; i++)
                {
                    if (matchCollection[i].Success)
                    {
                        items.Add(matchCollection[i].Value);
                    }
                }
                var index = item.IndexOf(items.Last()) + items.Last().Length;
                var final = item.Substring(index);
                if (final.Contains("\n"))
                {
                    items.Add(final);
                }
                else
                {
                    items[items.Count -1 ] = items[items.Count - 1] + final;
                }
                output.Add(items);
            }
