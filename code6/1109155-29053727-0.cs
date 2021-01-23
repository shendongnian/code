    PowerStatus ps = SystemInformation.PowerStatus;
    Console.WriteLine(" Charge Status: {0}", 
                         ps.BatteryChargeStatus.ToString());
    Console.WriteLine("     Full Life: {0}", 
                         ps.BatteryFullLifetime.ToString());
    Console.WriteLine("Life Remaining: {0}",
                         ps.BatteryLifeRemaining.ToString());
  
