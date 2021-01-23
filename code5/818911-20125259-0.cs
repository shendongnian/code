    public Class1 : IGetObject {
       public Foo GetObjectBy(string Id) 
       { 
          var id = Int32.Parse(Id); 
          //... 
       }
    }
    
    public Class2 : IGetObject {
       public Foo GetObjectBy(string Id) 
       {
           var id = new Guid(Id); 
           //... 
       }
    }
