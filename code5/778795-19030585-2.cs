    using (MyEntities context = new MyEntities())
    {
        return context.Companies
                      .Single(c => c.CompanyId == company.CompanyId)
                      .DataFile.Sum(d => d.FileSize);
    }
