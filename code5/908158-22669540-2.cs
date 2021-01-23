    using System;
    
    namespace ExampleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                new ToEraseClass("Boom!").GetData();
                Console.ReadLine();
            }
        }
    
        public class BaseErase
        {
            protected string ConnectionString
            {
                get; private set;
            }
    
            public BaseErase(string connectionString)
            {
                ConnectionString = connectionString;
            }
        }
    
        public class ToEraseClass : BaseErase
        {
            public ToEraseClass(string connectionString) : base(connectionString) 
            {}
    
            public void GetData()
            {
                Console.WriteLine(ConnectionString);
            }
        }
    }
