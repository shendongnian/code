    //C# example
    using TestFixture = MbUnit.Framework.TestFixtureAttribute;
    using Test = NUnit.Framework.TestAttribute;
    
    namespace MyTests
    {
        [TestFixture]
        public class UnitTest1
        {
            [Test]
            public void myTest()
            {
                //this will pass
            }
        }
    }
