    var model = (from c in General.db.GlbTbComboBases
                 where c.ClassCode.Equals(classCode)
                 select new ReturnData { id = c.BaseCode, name = c.FAName })
                .ToList() // this will load data into memory
                .OrderBy(c => c.id, new SemiNumericComparer());
