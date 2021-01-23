    class Program
    {
        static void Main()
        {
            var source = new DictionaryActivator();
            Console.WriteLine(source.GetInstance<Car>("MyCar").Price);
            Console.WriteLine(source.GetInstance<House>("MyHouse").Number);
            Console.WriteLine(source.GetInstance<Fruit>("MyFruit").Name);
            Console.Read();
        }
    }
