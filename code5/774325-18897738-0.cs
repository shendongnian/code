    public static void GetXmlDocValues(this List<MyClass> collection, XmlDocument xmlDoc)
    {
        collection.Clear();
        foreach (XmlNode item in xmlDoc.ChildNodes)
        {
            collection.Add(new MyClass(item));
        }
    }
