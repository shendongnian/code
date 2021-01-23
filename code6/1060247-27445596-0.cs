    foreach(var group in newList)
    {
        var id = group.Key;
        Console.Write("id=" + id)
        foreach(var item in group)
        {
            Console.Write(", name=" + item.name + ", value=" + item.value);
        }
        Console.WriteLine();
    }
