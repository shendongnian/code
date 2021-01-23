    List<string> positions = new List<string>();
     for (int i = 0; i < pv.Root.Parameter.Count; i++) 
     {
        if (name == pv.Root.Parameter[i].Name) 
        {
            positions.Add(name); //To get an element use positions.ElementAt(<index>)
        }
     }
