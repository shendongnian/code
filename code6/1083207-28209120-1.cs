    string original = @"someotherText http://instagram.com/p/xPnQ1ZIY2W/?modal=true some other text
    some other text http://instagram.com/p/xPnQ1ZIY2W/ some other text
    some other text http://instagr.am/p/xPnQ1ZIY2W/ some other text";
    
                StringBuilder result = new StringBuilder();
    
    
    
                using (StringReader reader = new StringReader(original))
                {
                    while (reader.Peek() > 0)
                    {
                        string line = reader.ReadLine();
                        if (reg.IsMatch(line))
                        {
                            string url = reg.Match(line).ToString();
                            result.AppendLine(reg.Replace(line,string.Format("<img src=\"{0}\" class=\"instagramimage\" />",url)));
                        }
                        else
                        {
                            result.AppendLine(line);
                        }
    
                    }
                }
    
                Console.WriteLine(result.ToString());
