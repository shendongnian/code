    // assuming some type for your other list
    class MyObject { public string Id { get; set; } }
    List<string> _order = new List<string>();
    List<MyObject> _objects = new List<MyObject>();
    var orderedList = from o in _order
                      join obj in _objects
                      on o equals obj.Id
                      orderby o
                      select obj;
 
