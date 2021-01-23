    public class Foo
    {
        private IPremiumResponse _premiumResponse;
        public Foo(IPremiumResponse premiumResponse)
        {
            _premiumResponse = premiumResponse;
        }
        public int DoSomeMathThenAddOne(int n)
        {
            return _premiumResponse.MultiplyValues(n, n) + 1;
        }
    }
