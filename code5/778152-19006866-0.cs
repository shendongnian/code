    public List<MyClass> Search(int valueToSearch)
    {
        var c = context.MyClasses.ToList(); // cache
        return c.Where(x => x.Values.Contains(valueToSearch));
    }
