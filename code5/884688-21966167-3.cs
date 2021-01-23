      using System;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                A a1 = new A(1), a2 = new A(1);
                //here  the  CLR  will do a lot of unboxing and check operations via reflection in  order to make a comparaison between fields value. 
                //just take a look bellow  at the decompiled default Equals method how it's  done 
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
    
       public  struct A : IEquatable<A>
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
             //here no boxing or  unboxing is needed  even if is a value  type  and the CLR will call this method first 
            public bool Equals(A other)
            {
                return this.Y == other.Y;   
            }
            public override bool Equals(object obj)
            {
                //this is  why a bad approach to compare both objects  you  need to unbox the struct arguments wich hurting  performance 
                return this.Y == ((A)obj).Y;
            }
    
           public override int GetHashCode()
           {
               return base.GetHashCode();
           }
    
           //default  implementation 
            //public override bool Equals(object obj)
            //{
            //    return base.Equals(obj);
            //}
        }
    }
