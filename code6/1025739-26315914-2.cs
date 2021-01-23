      List<string> stringList = new List<string>(){
                                            "name:john",
                                            "job:engineer",
                                            "description:engineering is blah blah blah blah blah bla",
                                            "blah blah blah blah blah bla",
                                            "drives a skooter",
                                            "name:Ted", 
                                            "job:engineer",
                                            "description:engineering is blah blah blah blah blah bla",
                                            "blah blah blah blah blah bla",
                                            "has a mustang",
                                            "name:Jim Bob", 
                                            "job:engineer",
                                            "description:engineering is blah blah blah blah blah bla",
                                            "blah blah blah blah blah bla",
                                            "drives a corvette"
                                            };
            StringBuilder sb = new StringBuilder();
            foreach (var mystring in stringList)
            {
                sb.Append(string.Format("{0} ", mystring));
            }
            sb.Replace("name:", "\nname:");
            string pattern = "(?=name)\\s*(?<name>.+)(?=job:)\\s*(?<job>.+)(?=description:)\\s*(?<description>.+)";
            
            foreach( Match m in Regex.Matches(sb.ToString(),pattern,RegexOptions.IgnoreCase))
            {
                string name = m.Groups["name"].Value.Trim();
                string job = m.Groups["job"].Value.Trim();
                string description = m.Groups["description"].Value.Trim();
                
            }   
