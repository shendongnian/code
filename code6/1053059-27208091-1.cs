    class Program
    {
        static void Main(string[] args)
        {
            // thoose are variables, and they are storing data
            int input = 0; // input integer number
            int sum = 0; // sum of all numbers
            while (true) //Infinite loop (executes undereneath code until true=true)
            {
                input = int.Parse(Console.ReadLine()); // read the line from user, parse to int, save to input variable
                if (input == -1) break; // if integer input is -1, it stops looping (the loop breaks) and GOES  (two lines down)
                sum = sum+ input; // summing all input (short version -> s+=input)
            }
              //HERE
            Console.WriteLine("Your sum is: " + s);
        }
    }
