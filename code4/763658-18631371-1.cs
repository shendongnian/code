    editableSacoche = SacocheDal.dbContext.Sacoches.Include("Contenus").First(i => i.SacocheID == editableSacoche.SacocheID);
                List<Contenu> contenuAjoute = contenus.Except(editableSacoche.Contenus.ToList(), new ContenuComparer()).ToList();
                foreach (Contenu c in contenuAjoute)
                {
                    editableSacoche.Contenus.Add(c);
                }
                SacocheDal.dbContext.SaveChanges();
