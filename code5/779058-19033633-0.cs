    class FooDesigner
    {
         private Foo foo;
         public FooDesigner(Foo foo)
         {
             this.foo = foo;
         }
         public int Prop1 
         { 
             get { return foo.Prop1; } 
             set { foo.Prop1 = value; } 
         }
         public BarDesigner Bar { get { return new BarDesigner(foo.Bar); } }
    }
    class BarDesigner
    {
         private Bar bar;
         public BarDesigner(Bar bar) 
         { 
             this.bar = bar;
         }
         public string Prop2 
         { 
             get { return bar.Prop2; } 
             set { bar.Prop2 = value; } 
         }
    }
