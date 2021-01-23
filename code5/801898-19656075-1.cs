    static void Main(string[] args)
    {
        bool run = true
        while(run){
           execute()
           Console.WriteLine("enter \"y\" to restart the program and \"n\" to exit the Program");
            selectedOption = Console.ReadLine();
            if (selectedOption == "n")
            {
                 run = false;
            }    
        }
    }
