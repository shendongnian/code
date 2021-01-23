    foreach(string s in lst)
    {
       if(s.StartsWith("[") && s.EndsWith("]"))
       {
             //add to OuterBracket_List
             OuterBracket_List.Add(s);
       }
       else 
       {        
           int n;
           if (int.TryParse(s, out n) == false)
           {             
                //add AlphaNumeric_List
                 AlphaNumeric_List.Add(s);
           }
           else
           {
                //add n to Numeric List
           }
       }
    }
