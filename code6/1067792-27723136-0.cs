    class Program
    {
        static void Main(string[] args)
        {
            TestDebuggerStepperBoundary();                        // Test 1
            Test();                                               // Test 2
            TestDebuggerNonUserCode(TestDebuggerStepperBoundary); // Test 3
            TestDebuggerNonUserCode(Test);                        // Test 4
        }
    
        [DebuggerNonUserCode]
        private static void TestDebuggerNonUserCode(Action action) { action(); }
    
        [DebuggerStepperBoundary]
        private static void TestDebuggerStepperBoundary() { SomethingHorrible(); }
    
        [DebuggerNonUserCode]
        private static void Test() { SomethingHorrible(); }
    
        private static void SomethingHorrible()
        {
            var foo = "bar";
        }
    }
