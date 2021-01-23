    foreach (Intersection fr in friends)
    {
       var g = GetGroupe(fr);
       if(g != null)
         this.Groupes.Remove(g);
    }
    
    
    Groupe GetGroupe(Intersection i)
    {
       return this.Groupes.FirstOrDefault(g => g.Contains(i));
    }
