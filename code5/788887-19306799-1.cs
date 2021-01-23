    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var map = new ObjectMap(new object[] {typeof(Class1)},
                      new object[] {typeof(Class2), "Arg One", 2});
            Assert.AreEqual(2, map.ActivatedObjects.Length);
            Assert.IsInstanceOfType(map.ActivatedObjects[0], typeof(Class1));
            Assert.IsInstanceOfType(map.ActivatedObjects[1], typeof(Class2));
        }
    }
    public class Class1
    {
        public Class1()
        {
        }
    }
    public class Class2
    {
        public Class2(string arg1, int arg2)
        {
        }
    }
