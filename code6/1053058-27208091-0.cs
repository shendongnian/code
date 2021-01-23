    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            int sum = 0;
            while((input = int.Parse(Console.ReadLine()))!=-1){ //Shortened second example
                sum += input;
            }
            Console.WriteLine("Your sum:" + sum);
    
    
            Console.WriteLine("Simplier method");
            int inp = 0; // input
            int s = 0;
            while (true) //Infinite loop (executes undereneath code until true=true)
            {
                inp = int.Parse(Console.ReadLine()); // read the line from user, parse to int, save to inp variable
                if (inp == -1) break; // if integer input is -1, it stops looping and GOES
                s += inp; // summing all input
            }
              //HERE
            Console.WriteLine("Your second sum" + s);
        }
    }
