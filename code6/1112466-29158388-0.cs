     [TestInitialize]
     public void TestInitialize()
     {
         MultiValueDictionary = new MultiValueDictionary<TestKey, string>();
     }
 
     protected static void AssertAreEqual( IDictionary<TestKey, string[]> expected,
     IMultiValueDictionary<TestKey, string> actual )
     {
         Assert.AreEqual( expected.Count, actual.Count );
         foreach ( var k in expected.Keys )
         {
             var expectedValues = expected[ k ];
             var actualValues = actual[ k ];
             AssertAreEqual( expectedValues, actualValues );
         }
     } 
