        int Rec = Convert.ToInt32(szUserRecID);
        var query = (from t in db.tblColors
                     join c in db.tblUser on t.fkColorID equals c.pkColorID
                     where t.fkRecID == Rec
                     select new ViewModels.ColorList()
                     {
                         ColorName = c.szColorName,
                         ID = t.ColorID
                     }).OrderBy(c => c.ColorName);
        //var q = query.ToArray(); // if I break and view q, the array exists
        return Json(query.ToArray());
    }
