    const double EORZEA_MULTIPLIER = 3600D / 175D; //175 Earth seconds for every 3600 Eorzea seconds
    
    // Calculate how many ticks have elapsed since 1/1/1970
    long epochTicks = DateTime.UtcNow.Ticks - (new DateTime(1970, 1, 1).Ticks);
    
    // Multiply that value by 20.5714285714...
    long eorzeaTicks = (long)Math.Round(epochTicks * EORZEA_MULTIPLIER);
    
    var eorzeaTime = new DateTime(eorzeaTicks);
