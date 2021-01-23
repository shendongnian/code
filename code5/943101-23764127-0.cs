    XmlAttributeCollection coll = element.Attributes;
    for (int i = 0; i < coll.Count; i++)
    {
        Console.WriteLine("name = " + coll[i].Name);
        Console.WriteLine("value = " + coll[i].Value);
    }
