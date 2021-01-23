    public static IEnumerable<dynamic> GetList()
    {
         var lst = (from l in Letters.ToList()
                   select new {Id = l.Id, Title = l.Title, UserName = l.tblUsers.Name}).ToList();
         return lst;
    }
