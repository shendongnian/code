    using System;
    static class Program
    {
        static void Main()
        {
            Console.WriteLine(Prop == null);
        }
        static int Prop
        { 
            get
            {
                throw new NotImplementedException("This error must be!"); 
            } 
        }
    }
