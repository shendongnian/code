    SchoolSoulLibrary.SchoolSoulDataEntities ss = new SchoolSoulLibrary.SchoolSoulDataEntities();
    string query1;
        var li = ss.Database.SqlQuery<MasterBank>(query1).Select(x => new {
            x.BankName,
            x.SchoolId
        }).ToList();
