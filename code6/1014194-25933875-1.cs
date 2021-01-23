    var s = new XmlSerializer(typeof(Test));
    using (XmlWriter x = new XmlTextWriter("test.xml", Encoding.UTF8))
    {
        s.Serialize(x, new Test { DateTime = DateTime.Parse("2014-10-20T10:46:00+01:00") });
    }
    using (var r = XmlReader.Create("test.xml"))
    {
       var o = (Test)s.Deserialize(r);
       var result = o.DateTime.ToString("HH:mm");
    }
