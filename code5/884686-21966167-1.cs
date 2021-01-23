    using System;
    
    namespace ConsoleApplication10
    {struct A:IEquatable<T>
    {
        int x;
        public A(int _x) { x = _x; }
        public int Y
        {
            get
            {
                Random r = new Random();
                return r.Next(0, 1000);
            }
        }
    
        public bool Equals(T other)
        {
     	    if(this.Y==(A(other).Y))
                return true ;  
            else 
                return  false ;  
        }
    }
    
    static void Main(string[] args)
    {
        A a1 = new A(1),a2 = new A(1);
        if (a1.Equals(a2))
        {
            Console.Write("Equals");
        }
        else
        {
            Console.Write("Different");
        }
    }    
    }
