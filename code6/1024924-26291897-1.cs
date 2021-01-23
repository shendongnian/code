    using System;
    using System.Text;
    using System.Collections.Generic;
    public class Base12 
    {
        public static void Main()
        {
            Base12 X = new Base12(10);
            Base12 X2 = new Base12(10);
            Base12 XX = X + X2;
            Console.WriteLine(XX); // outputs 18
        }
        public int DecimalValue { get; set; }
        
        public readonly char[] Notation = new char[] {'0', '1' , '2' , '3', '4', '5' , '6', '7', '8', '9', 'X', 'E'};
        
        public Base12(int x)
        {	
            DecimalValue = x;
        }
        
        public override string ToString()
        {
            List<char> base12string = new List<char>();
            int copy = DecimalValue;
            int counter = 0;
            while(copy > 0)
            {
                counter++;
                int result = copy % 12;
                base12string.Add(Notation[result]);
                copy = copy / 12;
            }
            
            StringBuilder str = new StringBuilder();
            for(int i = base12string.Count - 1; i >= 0; i--)
            {
                str.Append(base12string[i]);
            }
            return str.ToString();
        }
        
        public static Base12 operator+(Base12 x,  Base12 y)
        {
            return new Base12(x.DecimalValue + y.DecimalValue);
        }
        
        // Overload other operators at your wish
    }
