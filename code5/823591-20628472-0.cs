    [TestFixture] 
    public class When_calculating_sums
    {                    
        private MyCalculator _calc;
        private int _result;
        [SetUp] // Runs before each test
        public void SetUp() 
        {
            // Create an instance of the class to test:
            _calc = new MyCalculator();
			
            // Logic to test the result of:
            _result = _calc.Add(1, 1);
        }
        [Test] // First test
        public void Should_return_correct_sum() 
        {
            _result.ShouldEqual(2);
        }
		
        [Test] // Second test
        [ExpectedException(typeof (DivideByZeroException))]
        public void Should_throw_exception_for_invalid_values() 
        {
            // Divide by 0 should throw a DivideByZeroException:
            var otherResult = _calc.Divide(5, 0);
        }		
		
        [TearDown] // Runs after each test (seldom needed in practice)
        public void TearDown() 
        {
            _calc.Dispose(); 
        }
    }
