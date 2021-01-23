            public byte[] mainoutput(string text)
        {
            byte[] retval = null;
            
            char[] delimeterChars = { '?' };
            string[] newparsm = text.Split(delimeterChars);
            string query = "";
            int count = 0;
            foreach (string s in newparsm)
            {
                count += 1;
                if (s.Length > 2)
                {
                    if (count == 1)
                    {
                        query = query + "?" + s;
                    }
                    else
                    {
                        query = query + "&" + s;
                    }
                }
            }
            Console.WriteLine(query);
            
            return retval;
        }
