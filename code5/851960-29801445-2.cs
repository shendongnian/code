    //C# example
    using MbUnit.Framework;
    using NuTest = NUnit.Framework.TestAttribute;
    
    namespace MyTests
    {
        [TestFixture]
        public class UnitTest1
        {
            [Test, NuTest]
            public void myTest()
            {
                //this will pass
            }
        }
    }
