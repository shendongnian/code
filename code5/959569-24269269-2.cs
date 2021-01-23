    ps p;
    XmlSerializer serializer = new XmlSerializer(typeof(ps));
    using (StreamReader reader = new StreamReader("test1.xml"))
    {
        //basic exception handling...
        try
        {
            p = (ps)serializer.Deserialize(reader);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
     }
