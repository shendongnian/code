    static void Main(string[] args)
            {  
                double[,] Array = new double[,] { { 0, 0, 0}, { 0, 0, 0 }, { 0, 0, 0 } };
                //array Object = new array(); //no need of this because you are not using it any where
                Array[0,0] = Double.Parse(Console.ReadLine()); //"array" doesn't exist, it should be "Array"
                Console.WriteLine("Wert  = {0}",Array[0,0]); //"intArray" has not been initialized, it should be "Array" in you case
                Console.ReadKey();
            }
