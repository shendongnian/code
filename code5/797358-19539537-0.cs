    public class ToTest
    {
        private Random random = new Random();
        public virtual string MethodA()
        {
            return "Test";
        }
        public virtual int MethodB()
        {
            return random.Next();
        }
        public virtual string MethodC()
        {
            return MethodA() + " " + MethodB();
        }
    }
    [TestFixture]
    public class tests
    {
        [Test]
        public void Test_MethodC()
        {
            var mocks = new MockRepository();
            ToTest testedObject = mocks.CreateMock<ToTest>();
            testedObject.Expect(t => t.MethodA()).Return("AString");
            testedObject.Expect(t => t.MethodB()).Return(1324);
            Assert.AreEqual("AString 1324", testedObject.MethodC());
        }
    }
