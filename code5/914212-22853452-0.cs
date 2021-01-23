    using (var db = new DBContext())
    { 
       foreach (var element in foo)
       {
          db.list2.Add(element);
       }
       db.SaveChanges();
    }
