    using NUnitCommon;
    
    namespace NUnitSpecific
    {
        [TestFixture]
        public class SpecificTestClass : NUnitCommonTestClass
        {
            [Test]
            public void SpecificTestNoOne()
            {
                Assert.IsTrue(true);
            }
        }
    }
