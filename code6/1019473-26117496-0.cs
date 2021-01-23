    var model = (from c in General.db.GlbTbComboBases
             where c.ClassCode.Equals(classCode)
             select new { Id = Convert.ToInt32(c.BaseCode), Name = c.FAName })
             .OrderBy(c => c.Id)
            .Select(x => new ReturnData { id = x.Id, name = x.Name });
