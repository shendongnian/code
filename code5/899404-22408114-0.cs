    public class ProducerConsumerTest
    {
        private readonly BlockingCollection<int> _randomNumbersForFibonacci = new BlockingCollection<int>(10);
        private readonly BlockingCollection<int> _randomNumbersForPrime = new BlockingCollection<int>(10);
    
        int i = 0;
        int how_much_numbers = 20;
        int number = 0;
        private void Producer_t()
        {
            var random = new Random();
    
            for (i = 0; i < how_much_numbers; i++)
            {
                var randomNumber = random.Next();
    
                _randomNumbersForFibonacci.Add(randomNumber);
                _randomNumbersForPrime.Add(randomNumber);
            }
        }
        private void Consumer_t()
        {
            foreach (var randomNumber in _randomNumbersForFibonacci.GetConsumingEnumerable())
            {
                //Check if number is fibonaci
                Console.Out.WriteLine("IsFibonacci({0})", randomNumber);
            }
        }
        private void Consumer_t2()
        {
            foreach (var randomNumber in _randomNumbersForPrime.GetConsumingEnumerable())
            {
                //Check if number is primary
                Console.Out.WriteLine("IsPrime({0})", randomNumber);
            }
        }
    
        public void Run()
        {
            var producingTask = Task.Factory.StartNew(Producer_t);
    
            var fibonacciTask = Task.Factory.StartNew(Consumer_t);
    
            var primeTask = Task.Factory.StartNew(Consumer_t2);
        }
    }
