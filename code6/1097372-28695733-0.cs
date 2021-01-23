    class inner 
    {
       string baz = "hi";
       string blah = "hide me";
    }
    class outer 
    {
       int foo = 7;
       inner bar = new inner();
    }
    dynamic dyn = new {
       foo = outer.foo,
       bar = inner
    }
    string json = JsonConvert.SerializeObject(dyn);
