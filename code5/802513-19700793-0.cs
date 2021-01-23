    using (var context = new MyEntities(true))
    {
        string cpty = "MiCpty";
        DateTime date = DateTime.Today;
    
        var query = context.CECA_SPECIAL_CAS.Where(a => a.IDACUERDO == cpty 
                                                        && a.FECHAENTRADA == date);
        query.ToList();
    
        System.Diagnostics.Debug.Print(query.ToTraceString2());
    }
