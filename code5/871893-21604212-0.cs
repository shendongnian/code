    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to c#");
        Console.WriteLine("Please select an option.\n");
        Console.WriteLine("Select D for DownLoadPos(), U for UpLoadPos() ...\n");
        string input = Console.ReadLine();
        switch(input)
        {
              case "D": 
              { 
                   DownloadPOS();
                   break;
              }
              case "U": 
              { 
                   //UpLoadPOS(); // This is not a real method. Just for explanation
                   break;
              }
              default:
              {
                   Console.WriteLine("You have not selected an option.\n");
                   Console.WriteLine("The program will now exit. \n");                   
                   System.Threading.Thread.Sleep(1000);
              }
        }
    }
