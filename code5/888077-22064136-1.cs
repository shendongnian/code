    foreach (Intersection fr in friends)
    {
        var group = GetGroupe(fr);
        if(group != null)
           g.AddRange(group); //AddRange seems wrong here since group is not a collection
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
