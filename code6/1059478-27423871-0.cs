    var query = (from t in db.Table
                 group t by new {t.Description, t.Date }
                 into grp
                 select new
                 {
                     grp.Key.Description,
                     grp.Key.Date,                        
                 }).ToList();
