    public class Foo<T>
        {
            private T item;
    
            public Foo(T item)
            {
                this.item = item;
            }
    
            public bool IsNull()
            {
                return object.Equals(item, null);
            }
        }
    var fooStruct = new Foo<int?>(3);
                var b = fooStruct.IsNull();
    
                var fooStruct2 = new Foo<int?>(null);
                b = fooStruct2.IsNull();
    
                var fooStruct3 = new Foo<string>("qqq");
                b = fooStruct3.IsNull();
    
                var fooStruct4 = new Foo<string>(null);
                b = fooStruct4.IsNull();
