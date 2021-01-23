        [TestFixture]
        public class UnitTest1
        {
            [Test]
            public void TestMethod1()
            {
                var proxyGenerator = new ProxyGenerator();
                var testObject = proxyGenerator.CreateClassProxy<Test>();
                if (testObject.Status != null)
                {
                    Console.WriteLine("Working");
                }
                else
                {
                    Console.WriteLine("no....");
                }
            }
        }
    
        public class Test
        {
            public string Status { get; set; }
            public int Data { get; set; }
    
            public Test()
            {
                Status = "";
            }
        }
