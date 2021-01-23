     IEnumerable<Atom> GetAtoms()
     {
        foreach(Atom item in basis)
        {
             yield return item;
        }
        foreach(Atom item in atoms)
        {
             yield return item;
        }
     }
