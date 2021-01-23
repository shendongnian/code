        public class TestCaseGenerator : IEnumerable {
        
            #region Attributes
            internal static List<TestCase> TestCases { get; set; }
            internal int myInt { get; set; }
            internal string myString { get; set; }
            internal bool myBoolean { get; set; }
        
            #endregion
            static TestCaseGenerator() {
                var json = <jsonRepresentationOfMyTestData>
                TestCases = JsonConvert.DeserializeObject<List<TestCase>>(json);    
            }
            public IEnumerator GetEnumerator() {
                return TestCases != null
                          ? TestCases.Select(x => new TestCase(x.myInt, x.myString, x.myBool) ?? "null")).GetEnumerator()
                          : null;
            }
         }
