    [TestFixture]
    public class MyTests
    {
        [Test]
        [TestCaseSource(typeof(SmackTestDataProvider), "TestCases")]
        public void Smack(int a, int b) { ... }
    }
    
    public class SmackTestDataProvider
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData( 1, 2 );
                yield return new TestCaseData( 3, 4 );
                yield return new TestCaseData( 5, 6 );
            }
        }  
    }
