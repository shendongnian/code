    private List<string> MyList()
    {
        using (MyEntities ctx = new MyEntities())
        {
            var myList= ctx.Foo.Select(a => a.Bar).Distinct().OrderBy(a => a);
            return myList.ToList();
        }
    }
