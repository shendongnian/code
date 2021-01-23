    using(DataClassesDataContext db = new DataClassesDataContext())
    {
        string[] strings = File.ReadAllLines(Server.MapPath("~/str.txt"));
    
        foreach (var str in strings )
        {
            db.simpleTbl.InsertOnSubmit(new simpleTbl(){ Name = str });
        }
    
        db.SubmitChanges();
    }
