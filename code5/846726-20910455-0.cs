     public static List<object> processPage(string sourceCode)
    {
                //create List<object> to return
                List<object> ItemsToReturn = new List<object>();
                string Description = getBetween(sourceCode, @"Description:</td><td style=""padding-top: 5px; padding-bottom: 5px; font-size: 8pt; vertical-align: top;"">", "</td>");
                //add description (string) to List<object>          
                ItemsToReturn.Add(Description);
    
                //pull section to sort through from sourcecode
                string FullCashValue = getBetween(sourceCode, @"Full Cash Value</a>", "<a href");
                string[] FCVs = new string[2];
                //find index of $ sign
                int index1 = FullCashValue.IndexOf("$");
                //find $ amount + some extra characters for wiggle room
                FCVs[0] = FullCashValue.Substring(index1, 15).ToString(); //2014
                int index2 = FullCashValue.IndexOf("$", index1 + 1);
                FCVs[1] = FullCashValue.Substring(index2, 15).ToString(); //2013
    
                int[] int_FCVs = new int[5];
                for (int i = 0; i < FCVs.Count(); i++)
                {
                    // replace all non-digits with ""
                    var m = Regex.Replace(FCVs[i], @"[^.0-9]", "");
                    //convert var m to Int & place into array of ints
                    int_FCVs[i] = Convert.ToInt32(m);                
                }
                //put each int into ItemsToReturn (list<object>)
                foreach (int FCV in int_FCVs)
                {
                    ItemsToReturn.Add(FCV);
                } 
           return ItemsToReturn;
    }
