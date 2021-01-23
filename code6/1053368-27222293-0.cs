    bool All = true;
    foreach (var c in this.myWorkers)
    {
    
        bool Any = false;
        foreach (var cc in other.Workers)
            if (c.Equals(cc))
            {
                Any = true;
                break;
            }
    
        if (!Any)
        {
            All = false;
            break;
        }
    }
    
    myResults.Add(All);
