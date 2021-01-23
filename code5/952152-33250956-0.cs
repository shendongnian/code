    public class TestDataFixture
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                var testCases = new List<object[]>();
                var testCase = new object[1];
                var testData1 = new TestDataClass()
                {
                    name = "Piet",
                    surname = "Pompoies"
                };
                
                testCase[0] = testData1;
                testCases.Add(testCase);
                return testCases;
            }
        }
    }
    public class DieMatrixReloaded
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(TestDataFixture))]
        public void DieMatrixReloadedTheory(TestDataClass testData)
        {
            var someVar = testData;
            //Assert something here...
        }
    }
