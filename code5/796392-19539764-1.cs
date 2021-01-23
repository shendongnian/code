    [WebMethod]
            public  string[] GetItemsList(string PrefixText,int count)
            {
                char c1;
                char c2;
                char c3;`enter code here`
    
                if (count == 0)
                {
                    count = 10;
                }
                 Random rnd =new Random();
                 List<string> items = new List<string>();
                 for (int i = 0; i < count; i++)
                 {
                     c1 = Convert.ToChar(rnd.Next(65, 90));
                     c2 = Convert.ToChar(rnd.Next(97, 122));
                     c3 = Convert.ToChar(rnd.Next(97, 122));
                     items.Add(PrefixText + c1 + c2 + c3);
                 }
                     return items.ToArray();
            }
