    class Program
    {
        static void Main()
        {
            var source = new DictionaryActivator();
            Console.WriteLine(source.GetInstance<Car>("MyCar").Price);
            Console.WriteLine(source.GetInstance<House>("MyHouse").Number);
            Console.WriteLine(source.GetInstance<Fruit>("MyFruit").Name);
            var computer = source.GetInstance<object>("MyComputer", "Fast CPU", "Fast GPU");
            Console.WriteLine((computer as Computer).Cpu);
            Console.WriteLine((computer as Computer).Gpu);
            Console.Read();
        }
    }
