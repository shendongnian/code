    //this could be created in your unit tests proj
    public class MyBaseClassExtended : MyBaseClass
    {
        public MyBaseClassExtended () : base() { }
        public new object SomeProperty { get { return base.SomeProperty; }
    }
     //now I can test 
     [Test]
     public void Test()
     {
         var x= new MyBaseClassExtended ();
         Assert.IsNotNull(x.SomeProperty);
