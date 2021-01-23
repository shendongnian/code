        public class MyTestClass {
            [TestCaseSource(typeof(TestCaseGenerator))]
            public void MyTest(TestCase case) {
                // Do useful things with case.myInt, case.myString and case.myBool
            }
        }
