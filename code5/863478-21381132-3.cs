    class Adder
    {
        public static int sum = 0; // we made sum static (there is exactly one, instead of a separate sum for each instance)
        public static void Add(int x)
        {
            sum += x; // this refers to the static sum variable
        }
    }
    ...
    Adder.Add(5);
