    public class MyList<T> : List<T>
    {
        public int AddCallsCount;
        public new void Add(T t)
        {
            AddCallsCount++;
            base.Add(t);
        }
    }
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestThatsNotGood()
        {
            List<object> list = new MyList<object>();
            list.Add(1);
            list.Add(2);
            MyList<object> myList = list as MyList<object>;
            Assert.AreEqual(0, myList.AddCallsCount);
        }
    }
