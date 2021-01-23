    public override string ToString()
    {
        return this.Stringify(); //calls reusable code to "stringify" any object
    }
    //converts an object's properties to a string of pipe delimited values
    public static string Stringify<T>(this T obj)
    {
        var xs = new XmlSerializer(obj.GetType());
        var doc = new XDocument();
        using (var writer = doc.CreateWriter())
        {
            xs.Serialize(writer, obj);
        }
        var s = from text in doc.XPathSelectElements("//*[./text()]") select text.Value;
        return string.Join("|", s);
    }
