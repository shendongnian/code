    namespace ConsoleApplication1
    {
        public static class Arithmetic
        {
            public static int Add(int opreand1, int opreand2);      //Closing semicolon means an empty function def
            public static int Subtract(int opreand1, int opreand2); //Same
            public static int Multiply(int opreand1, int opreand2 ); //Same
            public static int Divide(int opreand1, int opreand2); // Same
        } //This closing curly brace closed the class definition
    
            { //This opening curly brace doesn't make any sense, you are starting a new scope in the namespace, which isn't allowed.
             return opreand1 + opreand2; //Fine if this was the add function
             return opreand1 - opreand2; //Couldn't hit this line since you returned above
             return opreand1 * opreand2; //Same
             return opreand1 / opreand2; //Same
    
            } //Closed the undefined namespace-level scope
        { //Same as before, you are opening a scope in the namespace.
    
    Console.WriteLine ("1+1={0}\r\n2+2={1}\r\n3+3={2}\r\n4+4={3}\r\n",  
                    Arithmetic.Add (1, 1), Arithmetic.Add (2,2), Arithmetic.Add(3,3), 
                    Arithmetic.Add(4,4));
    Console.WriteLine("4-2={0}\r\n8-4={1}\r\n16-8={2}\r\n",
                    Arithmetic.Subtract(4, 2), Arithmetic.Subtract(8, 4), 
                    Arithmetic.Subtract(16, 8));
    Console.WriteLine("4*2={0}\r\n8*4={1}\r\n",
                    Arithmetic.Multiply(4, 2), Arithmetic.Multiply(8, 4));
    Console.WriteLine("4%2={0}\r\n",
                    Arithmetic.Divide(4, 2));
    Console.WriteLine("No. Add={0}\r\nNo. Subtract={1}\r\nNo. Multiply={2}\r\nNo. Divide={3}",
                    Arithmetic.numAdd, Arithmetic.numSubtract, Arithmetic.numMutiply                           
                    Arithmetic.numDivide); //All these don't exist. If they are methods, you are passing the delegate, not the return of the method call.
     }
