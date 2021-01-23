    static bool string_parser(string str_to_parse)
            {
                bool result= false;
                string[] parts = str_to_parse.Split(' ');
                if (parts.Length == 3)
                {
                    if (parts[0].ToLower().Contains("true"))
                    {
                        result = true;
                    }
                    if (parts[1].ToLower().Contains("or"))
                    {
                        if (parts[2].ToLower().Contains("true"))
                        {
                            result= result || true;
                        } 
                    }
                    else if (parts[1].ToLower().Contains("and"))
                    {
                        result = parts[2].ToLower().Contains("true") ? result && true : result && false;
                    }
                }
                return result;
            }
