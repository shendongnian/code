         List<string> lst = new List<string>();
         lst.Add("aaa");
         lst.Add("bbb");
         foreach (string curr in lst)
         {
            if (curr.Equals("aaa"))
            {
               lst.Remove(curr);
            }
         }
