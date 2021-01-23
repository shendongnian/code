    private static void Main()
    {
        SettingsComponent.LoadSettings();
        while (true)
        {
            try
            {
                 for(int x=0; x<4 ; x++){
                    GenerateRandomBooking(); // Will call 5 times
                 }
                 Thread.Sleep(2000) // 2 seconds sleep
                 GenerateRandomBids();
                 AllocateBids();           
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
          
        }
    }
