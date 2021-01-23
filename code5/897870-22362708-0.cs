    public class MySubObject : MyObject { ... }
    var obj = new MySubObject();
    
    Assert.AreEqual(obj.GetType(), typeof(MyObject));   //fails
    Assert.IsInstanceOfType(obj, typeof(MyObject));     //passes
