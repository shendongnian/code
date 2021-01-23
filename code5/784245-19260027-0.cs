    using System;
    
    namespace MyLibrary
    {
        public class MyClass
        {
            // function that does some work and notify listeners of occurred events
            public void FindPrimes()
            {
                // Primes between 1 and 10000
                for (int i = 1; i < 10000; i++)
                {
                    if (MyClass.isPrime(i))
                    {
                        //System.Console.WriteLine(i);
                        onPrimeFound(i);
                    }
                }
            }
    
            // helper function to determine if number is prime
            public static bool isPrime(int x)
            {
                if (x == 1) return false;
                if (x == 2) return true;
                for (int i = 2; i <= Math.Ceiling(Math.Sqrt(x)); i++)
                {
                    if (x % i == 0) return false;
                }
                return true;
            }
    
            // event broadcasted
            public event EventHandler PrimeFound;
            protected void onPrimeFound(int x)
            {
                var handler = this.PrimeFound;
                if (handler != null)
                {
                    handler(this, new PrimeEventArgs(x));
                }
            }
        }
    
        // event data passed to listeners
        public class PrimeEventArgs : EventArgs
        {
            public readonly int number;
            public PrimeEventArgs(int x)
            {
                this.number = x;
            }
        }
    }
