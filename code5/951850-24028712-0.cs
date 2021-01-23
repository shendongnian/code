    public IEnumerable<KeyValuePair<decimal, string>> getDepartments()
    {
        using (DBEntities db = new DBEntities ())
        {
            var dept = (from i in db.Departments
                        orderby i.DepartmentName
                        select new
                        {
                            i.Id,
                            i.DepartmentName
                        }).ToDictionary(Key => Key.Id, Value => Value.DepartmentName);
            foreach(var item in dept)
               yield return item;
        }
    }
