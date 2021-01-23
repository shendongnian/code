    public class HappyDecorator
    {
        public string SpecialFactor { get; set; }
        public void printMe<T>(T instance) where T : HappyObject
        {
            Console.WriteLine(SpecialFactor);
            instance.print();
        }
    }
