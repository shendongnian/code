    [TestClass]
    public class SomeTestClass
    {
        [TestMethod]
        public void TestMethod()
        {
            for (var i = 0; i < 100; i++) Test();
        }
        private static void Test()
        {
            Pipe.counter = 0;
            var list = new List<string>();
            var p = new BlockingPipe(list);
            var f = Task.Factory;
            var b = new Barrier(3);
            f.StartNew(() => { p.Client("asdf"); b.SignalAndWait(); });
            f.StartNew(() => { p.Server("qwer"); b.SignalAndWait(); });
            b.SignalAndWait();
            var exp = String.Join("\n", 
              new[] { "server0 processes qwer", "client0 processes asdf" });
            var act = String.Join("\n", list);
            Assert.AreEqual(exp, act);
        }
    }
