    HashSet<string> hs = new HashSet<string>();
    
    foreach(string s in myList)
    {
       if(hs.Contains(s)) 
       {
          Debug.WriteLine("dup: " + s);
       }
       else 
       {
          hs.Add(s);
       }
    }
