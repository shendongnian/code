    interface ICar {}
    interface IAnimal {}
    
    class Program
    {
        static void Dispatch(dynamic list)
        {
            Console.WriteLine("Dispatch called");
            DoSomething(list);
        }
    
        static void DoSomething<T>(List<T> genericList)
        {
            Console.WriteLine("Generic unconstrained method called");
        }
    
        static void DoSomething(List<IAnimal> animalList)
        {
            Console.WriteLine("Do something WILD");
        }
    
        static void DoSomething(List<ICar> carList)
        {
            Console.WriteLine("Calculate loans");
        }
    
        static void Main()
        {
            object deserializedList = new List<ICar>();
            Dispatch(deserializedList);
        }
    }
