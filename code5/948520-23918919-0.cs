    public JsonResult BillPh(string Pays)
    {
        string codePays = db.liste_pays.FirstOrDefault(f => 
                                                   f.Pays.ToUpper() == Pays.ToUpper())
                                                    .CodePays.ToString();
    }
