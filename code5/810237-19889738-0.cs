    class Program
    {
        public interface IFoo
        {
            void DoSomething();
        }
    
        public interface IGenericFoo<out T> : IFoo
        {
            T GetDefault();
        }
    
    
        public class Foo<T> : IGenericFoo<T>
        {
            public T GetDefault()
            {
                return default(T);
            }
    
            public void DoSomething()
            {
                Console.WriteLine("Meep!");
            }
        }
    
    
        private static void Main()
        {
    
            var fooCollection = new List<IFoo>
            {
                new Foo<string>(), 
                new Foo<StringBuilder>(),
                new Foo<int>()
    
            };
            foreach (var instance in fooCollection)
                instance.DoSomething();
            
            // Covariance example
            var fooCollectionGenericI = new List<IGenericFoo<object>>
            {
                new Foo<string>(), 
                new Foo<StringBuilder>(),
                // new Foo<int>() not possible since covariance is not supported on structs :( 
            };
    
            foreach (var instance in fooCollectionGenericI)
            {
                var wxp = instance.GetDefault();
                Console.WriteLine(wxp == null ? "NULL" : wxp.ToString());
            }
    
            Console.ReadLine();
        }
    }
