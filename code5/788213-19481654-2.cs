        class FooFactory
        {
            static Foo CreateFoo(int bar,string baz)
            {
                  if(baz == "a")
                      return new Foo1(bar,baz);
                  else if(baz == "b")
                      return new Foo2(bar,baz);
                  ........
            }
        }
        abstract class Foo
        {
              public int bar{get;protected set;}
              public string baz{get;protected set;}
              //this method will be overriden by all the derived class to do
              //the initialization
              abstract void Initialize();
        }
