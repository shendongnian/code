         List<string> lst = new List<string>();
         lst.Add("aaa");
         lst.Add("bbb");
         List<string> lstToDel = new List<string>();
         foreach (string curr in lst)
         {
            if (curr.Equals("aaa"))
            {
               lstToDel.Add(curr);
            }
         }
         foreach (string currToDel in lstToDel)
         {
            lst.Remove(currToDel);
         }
