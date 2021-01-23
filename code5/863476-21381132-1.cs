    class Adder
    {
        public int sum = 0;
        public static void Add(int x)
        {
            sum += x; // can't reference "sum" from static method! 
        }
    }
    ...
 
    Adder.Add(5)
