    private void Ajout_MouseDoubleClick(object sender, MouseButtonEventArgs e, )
    {
        DBSet<Resultat> res=YourDbContext.Resultats;
        var add = from a in res
              where a.Remarque.Equals("Ajoute")
              select new { a.Groupe_D_alerte, a.Remarque }
    }
