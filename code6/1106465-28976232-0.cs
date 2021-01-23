    public class HappyDecorator<T> where T : HappyObject
    {
        private readonly T _instance;
        public HappyDecorator(T instance)
        {
            _instance = instance;
        }
        public string SpecialFactor { get; set; }
        public void printMe()
        {
            Console.WriteLine(SpecialFactor);
            _instance.print();
        }
    }
