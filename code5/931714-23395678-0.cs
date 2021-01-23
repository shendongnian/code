     for (int k=tagstArray.Count; k>0; k--)
       {
           s = tagstArray[k].ToString();
           if(s.Contains("Jad"))
            {
               tagstArray[k].Remove(k);
            }
        }
