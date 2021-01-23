    private void button1_Click(object sender, EventArgs e)
    {
        using (KrqcSDBEntities context = new KrqcSDBEntities())
        {
            activite monActivite = new activite();
            monActivite.lieu_activite = "Paris";
            monActivite.nom_activite = "Natation";
            context.activite.AddObject(monActivite);
            context.SaveChanges();
            activite test = context.activite.FirstOrDefault(o => o.id == 1);
        }
    }
