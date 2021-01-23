    var db = new XXX_DevEntities();
    int YearMax = DateTime.Today.AddYears(5).Year;
    var existent = (from a in db.BusinessDays
                   where a.Year < YearMax
                   select a).ToList();
    foreach (var aj in ajustes)
    {
        for (int i = 1; i < 13; i++)
        {
            var codBusinessDay = diasUteisExistentes.Where(x => x.Year == aj.Year && x.Month == i).Select(x => x.CodBusinessDay).FirstOrDefault();
            var entidade = new BusinessDays { CodBusinessDay = codBusinessDay };
            db.BusinessDays.Attach(entidade);
            entidade.Year = aj.Year;
            entidade.Month = i;
            entidade.Qtd = aj.ValorMonth(i);
            db.Entry(entidade).State = codBusinessDay > 0 ? EntityState.Modified : EntityState.Added;
        }
    }
    
    db.SaveChanges();
