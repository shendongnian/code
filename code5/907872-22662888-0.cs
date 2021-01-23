    // A Test object
    class MyObject
    {
        public int ID {set;get;}
        public int? MyProperty {set;get;}
    }
    
    void Foo()
    {
        var test = new MyObject();
        db.MyObjects.Add(test);
        db.SaveChanges();
        
        // at this moment test has the Id set. You can assign it.
        test.MyProperty = test.Id;
        db.SaveChanges();
    }
