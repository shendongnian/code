    public static MyObject Create(XElement e)
        {
            var obj = Create();
            obj.A= e.Element("A").Value;
            obj.B= e.Attribute("B").Value;           
            return obj;
        }
