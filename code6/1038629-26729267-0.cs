    public static void SortBlocks(MyClass obj)
    {
        List<Animal> value = obj.AnimalList;
        value = value.OrderBy(val => val.Age).ToList();
        obj.AnimalList = value;
    }
