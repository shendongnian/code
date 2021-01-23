    class mytype
    { 
     public int id;
     public string title;
     public string name;
    }
    public static List<mytype> GetList()
    {
     return (from l in Letters.ToList() select new mytype{id=l.Id,title=l.Title,  name=l.tblUsers.Name}).ToList();
    }
