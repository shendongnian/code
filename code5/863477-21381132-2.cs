    class Adder
    {
        public int sum = 0;
        public void Add(int x) // no longer static
        {
            sum += x; // this refers to the "sum" variable of this particular instance of Adder
        }
    }
    ...
    var adder = new Adder();
    adder.Add(5);
