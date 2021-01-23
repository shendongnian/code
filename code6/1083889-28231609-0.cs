            List<string> list = new List<string>();
            list.Add("abc.com");
            list.Add("def.com");
            list.Add("ijk.com");
            list.Add("pages.abc.com");
            list.Add("help.abc.com");
            list.Add("contactus.def.com");
            list.Add("help.def.com");
            List<string> listRoot = new List<string>();
            List<string> listSub = new List<string>();
            foreach (string item in list)
            {
                string[] split = item.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length == 2)
                {
                    listRoot.Add(item);
                }
                else
                {
                    listSub.Add(item);
                }
            }
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            foreach (string root in listRoot)
            {
                List<string> listSubIntern = new List<string>();
                foreach (string item in listSub)
                {
                    if (item.EndsWith(root, StringComparison.InvariantCultureIgnoreCase))
                    {
                        listSubIntern.Add(item);
                    }
                }
                dictionary.Add(root, listSubIntern);
            }
            foreach (KeyValuePair<string, List<string>> keyValuePair in dictionary)
            {
                Console.WriteLine(keyValuePair.Key);
                foreach (string s in keyValuePair.Value)
                {
                    Console.WriteLine("\t{0}", s);
                }
            }
