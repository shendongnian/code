    class Program
    {
        static void Main(string[] args)
        {
            int User;
            int Array;
    		bool isUserWrong = true;  //This is a flag that we will use to control the flow of the loop
            StreamWriter outfile = new StreamWriter("C://log.txt");
    		
            while(isUserWrong)
            {
    			Console.WriteLine("Input an number between 1 and 100");
    			User = Convert.ToInt32(Console.ReadLine());
    			if (User < 101 && User > 0)
    			{
    				for (Array = 1; Array <= User; Array++)
    				{
    					Console.WriteLine(Array + ", " + Array * 10 * Array);
    					outfile.WriteLine(Array + ", " + Array * 10 * Array);
    				}
    				isUserWrong = false; // We signal that we may now leave the loop
    			}
    			else
    			{
    				Console.WriteLine("Sorry you input an invalid number. ");
    				Console.ReadLine();
    				//Note that here we keep the value of the flag 'true' so the loop continues
    			}
    		}
    		Console.WriteLine("Press Enter To Exit The Console");
    		outfile.Close();
    		Console.ReadLine();
        }
    }
