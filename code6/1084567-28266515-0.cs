    public class Foo
    {
        public virtual int DoSomething()
        {
            return 10;
        }
    }
    public class Bar : Foo
    {
        public override int DoSomething()
        {
            return 9;
        }
    }
    [TestFixture]
    public class Tests
    {
        private Foo[] _foos = { new Foo(), new Bar() };
        [Test]
        [TestCaseSource("_foos")]
        public void When_DoSomething_Is_Invoked_Then_A_Power_Of_Ten_Is_Returned(Foo sut)
        {
            Assert.That(sut.DoSomething() % 10, Is.EqualTo(0));
        }
    }
