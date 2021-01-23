    using System;
    
    interface IFoo
    {
        void Bar();
    }
    
    class Normal : IFoo
    {
        public void Bar()
        {
            Console.WriteLine("Normal.Bar");
        }
    }
    
    class Extended1 : Normal
    {
        public new void Bar()
        {
            Console.WriteLine("Extended1.Bar");
        }
    }
    
    class Extended2 : Normal, IFoo
    {
        public new void Bar()
        {
            Console.WriteLine("Extended2.Bar");
        }
    }
    
    class Test
    {
        static void Main()
        {
            IFoo x = new Extended1();
            IFoo y = new Extended2();
            
            x.Bar();
            y.Bar();
        }
    }
