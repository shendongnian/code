    var lCandidat = new List<Candidat>();
    
    lCandidat.Add(new Candidat{ Id = 2, num_cin = "xabc", postes = new Collection<Poste>()
    {
        new Poste {Id = 10, poste_name = "id10"},
        new Poste {Id = 15, poste_name = "id15"}
    }});
    lCandidat.Add(new Candidat{ Id = 1, num_cin = "abc15", postes = new Collection<Poste>()
    {
        new Poste {Id = 3, poste_name = "3"},
        new Poste {Id = 4, poste_name = "id4"}
    }});
    //get candidat
    var v = (from c in lCandidat
        where c.num_cin == "abc15"
              && c.postes.Any(p => p.Id == 3)
        select c)
        .FirstOrDefault();
    
    
    var v2 = lCandidat.Where(c => c.num_cin == "abc15"
                              && c.postes.Any(p => p.Id == 3))
                             .Select(c => c).FirstOrDefault();
    
    
    
    Console.WriteLine("v query ID {0}, cin {1}", v.Id, v.num_cin);
    Console.WriteLine("v2 query ID {0}, cin {1}", v2.Id, v2.num_cin);
