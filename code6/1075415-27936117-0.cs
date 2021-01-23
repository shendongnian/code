    List<Organism> Organisms = OrganismDT.AsEnumerable().Select(row =>
              new Organism
              {
                AliasId = row.Field<int>("OrganismAliasId"),
                Name = row.Field<string>("Name"),
                Antibiotics = AntibioticsDT.AsEnumerable()
                            .Where(x => x.Field<int>("OrganismAliasId") 
                                           == row.Field<int>("OrganismAliasId"))
                            .Select(x => new Antibiotic
                            {
                               Name = x.Field<string>("Name"),
                               Susceptibility = x.Field<string>("Susceptibility")
                            }).ToList()
                }).ToList();
