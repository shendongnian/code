    class MyClass
    {
        public int id { get; set; }
        public string[] officeId { get; set; }
    }
    var objects = new List<MyClass>
                      {
                          new MyClass{id=1, officeId=new[]{"office1","Office2","Office3"}},
                          new MyClass {id=2,officeId=new[]{"office1","Office2","Office3"}},
                          new MyClass{id=3, officeId=new[]{"office1","Office2","Office3"}}
                      };
    
    
    var enumerable = objects.SelectMany(@class => @class.officeId).GroupBy(s => s).Select(a => new { officeId = a.Key, count = a.Count() });
