    public class CalculatorTests
    {
        private readonly Calculcator _calculator;
    
        public CalculatorTests()
        {
            var mock = new Mock<IAddModule>();
            mock.Setup(x => a.Add(2, 2)).Returns(4);
            _calculator = mock.Object;
        }
        
        [Fact]
        public void Given_2_And_2_Then_4_Is_Returned()
        {
            var result = _calculator.Add(2, 2);
            
            Assert.Equal(4, result);
        }
    }
