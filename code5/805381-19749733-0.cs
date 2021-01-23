            string input = "req:{REQUESTER_NAME},key:{abc},act:{UPDATE},sku:{ABC123,DEF-123},qty:{10,5}";
            Console.WriteLine(input);
            string[] words = input.Split(new string[] { "}," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in words)
            {
                if (item.Contains(':'))
                {
                    string modifiedString = item.Replace(",", "," + item.Substring(0, item.IndexOf(':')) + ":");
                    string[] wordsColl = modifiedString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item1 in wordsColl)
                    {
                        string finalString = item1.Replace("{", "");
                        finalString = finalString.Replace("}", "");
                        Console.WriteLine(finalString);
                    }
                }
            }
