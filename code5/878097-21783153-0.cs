    public static string getName(string line)
            {
                string ret = "";
    
                if (!line.Contains("ID="))
                    return ret;
                var regex = ".*ID=\"(.*?)\".*";
                if (Regex.IsMatch(line, regex) )
                    ret = Regex.Match(line, regex).Groups[1].Value;
                return ret;
            }
