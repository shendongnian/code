    ...
    Console.WriteLine("Waiting for the service to stop. Press enter to exit.");
    while(true){
       try {
         string keyIn = Reader.ReadLine(500);
         break;
       } catch (TimeoutException) {
         System.Threading.Thread.Sleep(100);
       } 
    }
