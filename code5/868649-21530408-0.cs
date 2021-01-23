            List<string> possibleMatches = new List<string>();
            string expression = "123?[3-9]" //this is an example
            if (expression.Contains("?") || expression.Contains("["))
            {               
                int count = expression.Count(f => f == '?');
                count += expression.Count(f => f == '[');
                if (count <= 2)
                {
                    string pattern = expression.Replace('*', '.').Replace('?', '.');
                    pattern = pattern.Replace(".", "[0-9]"); 
                    int pos1 = pattern.IndexOf('[');
                    int start1 = Convert.ToInt32(pattern[pos1 + 1].ToString());
                    int end1 = Convert.ToInt32(pattern[pos1 + 3].ToString());
                    
                    int pos2 = 0;
                    int start2, end2 = 0;
                    if (count > 1)
                    {
                        pos2 = pattern.IndexOf('[', pos1);
                        start2 = Convert.ToInt32(pattern[pos2 + 1].ToString());
                        end2 = Convert.ToInt32(pattern[pos2 + 3].ToString());
                        pattern = pattern.Remove(pos1, "[0-9]".Length);
                        pattern = pattern.Remove(pos2, "[0-9]".Length);
                        string copy = pattern;
                        for (int i = start1; i <= end1; i++)
                        {
                            copy = pattern.Insert(pos1, i.ToString());
                            for (int y = start2; y <= end2; y++)
                            {
                                possibleMatches.Add(copy.Insert(pos2, y.ToString()));
                            }
                        }
                    }
                    else
                    {
                        pattern = pattern.Remove(pos1, "[0-9]".Length);
                        for (int i = start1; i <= end1; i++)
                        {
                            possibleMatches.Add(pattern.Insert(pos1, i.ToString()));
                        }
                    }
                }
