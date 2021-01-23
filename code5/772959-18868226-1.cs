    using(XmlReader r = XmlReader.Create(new StreamReader(
                            fileName, Encoding.GetEncoding("UCS-2"))))
    {
        while(r.Read())
        {
            Console.WriteLine(r.Value);
        }
    }
