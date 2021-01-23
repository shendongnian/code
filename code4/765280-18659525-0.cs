    public class MyBaseClassExtended : MyBaseClass
    {
        public MyBaseClassExtended () : base() { }
        public new object SomeProperty { get { return base.SomeProperty; }
    }
     //now I can test (this is in you unit tests...)
     [Test]
     public void Test()
     {
         var x= new MyBaseClassExtended ();
         Assert.IsNotNull(x.SomeProperty);
