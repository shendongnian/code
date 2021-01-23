    class Program
    {        
        static void Main(string[] args)
        {            
            Arrays[] arr = new Arrays[500]; //Initialize an array
            arr[2].X = 11;     
            foreach (var i in arr) //Trying to loop through
            {
                Console.WriteLine(i); //Result: Array.Array
            }
        }
    }
    public struct Arrays
    {
        public Int32 X, Y;      
  
        public override string ToString()
        {
            return X + " x " + Y;
        }
    }  
