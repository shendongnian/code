    private static void Main()
        {
            SettingsComponent.LoadSettings();
            //while (true)
            {
                try
                {
                    RaiseRandomBooking(null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        static void RaiseRandomBooking(object state)
        {
            for (int x = 0; x < 4; x++)
            {
                GenerateRandomBooking();
            }
            System.Threading.Timer tmr = new System.Threading.Timer(RaiseRandomBids, null, 0, 2000);
        }
        static void RaiseRandomBids(object state)
        {
            GenerateRandomBids();
            AllocateBids();
            System.Threading.Timer tmr = new System.Threading.Timer(RaiseRandomBooking, null, 0, 2000);
        }
