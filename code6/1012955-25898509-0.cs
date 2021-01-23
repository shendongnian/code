    using System;
    namespace PWS
    {
        public class Scope
        {
            public int Objective { get; set; }
            
            public Scope()
            {
                Objective = 0;
            }
            
            public void Connect()
            {
                Console.WriteLine("connected");
            }
        }
    }
