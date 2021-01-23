    class Foo {
        public int A {get;set;}
        public string B {get;set;}
    }
    
    Foo foo = new Foo {A = 1, B = "abc"};
    foreach(var prop in foo.GetType().GetProperties()) {
        if(prop.PropertyType == typeof(int?)) // int? can be changed bythe type of your variable
        {
               if(prop.GetValue(foo, null) == null) // null can be changed to your verification, == 0  whatever.
               {
                  //do some
               }
        }
    }
