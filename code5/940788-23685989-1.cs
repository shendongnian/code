        private static List<string> GetCommands(string location)
        {
            List<string> ret = new List<string>();
            List<string> tmp = ReadFile(location, new string[] { "\r\n\r\n"});
            for (int i = 0; i < tmp.Count; i++)
            {
                string rem = tmp[i].Replace("\r", "");
                ret.Add(rem);
            }
            return ret;
        }
