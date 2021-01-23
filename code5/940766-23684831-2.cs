    Dictionary<string, myclass> dl = new Dictionary<string, myclass>();    
    foreach(string s in myList)
    {
       if(dl.ContainsKey(s)) 
       {
          Debug.WriteLine("dup: " + s);
       }
       else 
       {
          dl.Add(s, null);
       }
    }
