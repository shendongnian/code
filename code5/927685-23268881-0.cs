    public class SomeClass
    {
        public virtual int Method(int arg1, int arg2)
        {
            return 7;
        }
    }
     
    [TestFixture]
    public class TestFixture
    {
        [Test]
        public void Should_be_able_to_set_return_value()
        {
            const int param1 = 9;
            var fakeInstanse = A.Fake<SomeClass>();
            A.CallTo(() => fakeInstanse.Method(param1, param1))
                .Returns(8);
            Assert.That(fakeInstanse.Method(param1, param1), Is.EqualTo(8));
        }
    }
