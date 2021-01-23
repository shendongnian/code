    class Foo
    {
        public dynamic V { get; set; }
    }
            
    var f1 = new Foo(){V = 5};    
    var tw2 = new StringWriter();
    new Serializer().Serialize(tw2, f1);
    var tr2 = new StringReader(tw2.ToString());
    var f_1 = new Deserializer().Deserialize<Foo>(tr2);
