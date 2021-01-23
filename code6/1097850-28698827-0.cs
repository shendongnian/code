    public void RemoveCompany(long companyId)
    {
        using (var db = new BoilerServicingDbContext())
        {
            var engineerIds = db.Engineers
                                .Where(x => x.CompanyId == companyId)
                                .Select(x => x.Id).ToList();
    
            var sql  = "DELETE FROM Engineers WHERE Id IN ({0})";
            sql = string.Format(sql, string.Join(", ", engineerIds);
            db.Database.ExecuteSqlCommand(sql);
            db.SaveChanges();       
        }
    }
