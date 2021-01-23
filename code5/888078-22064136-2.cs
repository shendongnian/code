    foreach (Intersection fr in friends)
    {
        var group = GetGroupe(fr);
        if(group != null)
           g.AddRange(group);
    }
    foreach (Intersection fr in friends)
    {
       var group = GetGroupe(fr);
       if(group != null)
         this.Groupes.Remove(group);
    }
    
    
    Groupe GetGroupe(Intersection i)
    {
       return this.Groupes.FirstOrDefault(g => g.Contains(i));
    }
