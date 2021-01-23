    static void Main(string[] args)
        {
            int wgt = 0;
            Console.WriteLine("Please Enter the Turtle's Weight: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out wgt)) {
                Turtle turt = new Turtle(wgt);
                Console.Write(turt.getWeight());
            } else {
                Console.WriteLine("You must enter an integer.");
            }
            
            Console.WriteLine("\nPres Any Key To End");
            Console.ReadKey();
        }
