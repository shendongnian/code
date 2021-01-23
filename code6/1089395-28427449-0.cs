    private static void Main()
    {
        SettingsComponent.LoadSettings();
        int Count =0;
        while (true)
        {
            try
            {
                 GenerateRandomBooking();
                 GenerateRandomBids();
                 AllocateBids();
                 Count ++;            
                 
                 if(Count > 4){
                    Thread.Sleep(2000) // 2 seconds
                    Count = 0;
                 }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
          
        }
    }
