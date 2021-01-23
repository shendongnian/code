    public class Foo
    {
        public IEnumerable<int> Numbers { get; private set; }
    
        public Foo(IEnumerable<int> numbers)
        {
            this.Numbers  = numbers;
        }
    }
