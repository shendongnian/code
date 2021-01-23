    public static string toUpper(string mytext)
            {
                if (String.IsNullOrWhiteSpace(mytext)) { return mytext; }
    
                mytext = mytext.Trim();
    
                if (mytext.EndsWith("."))
                {
                    if (mytext.Length == 1)
                    {
                        return mytext;
                    }
                    else
                    {
                        string first = mytext.First();
                        mytext = String.Join(first.ToUpper(), mytext.Substring(1));
                    }
                }
                else
                {
                    if (mytext.Length == 1)
                    {
                        mytext = String.Join(mytext.ToUpper, ".");
                    }
                    else
                    {
                        string first = mytext.First();
                        mytext = String.Join(first.ToUpper(), mytext.Substring(1));
                    }
    
                }
                return mytext;
            }
