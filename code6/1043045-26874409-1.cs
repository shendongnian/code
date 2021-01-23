    [TestClass]
    public class SomeClassTest
    {
        [TestMethod]
        public void SomeMethodShouldThrow()
        {
            Action invocation = () => new SomeClass().SomeMethod();
            invocation.ShouldThrow<ConfigurationNotFoundException>().WithMessage("Hey!");
        }
    }
