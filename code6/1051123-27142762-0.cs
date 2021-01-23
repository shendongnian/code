    long epochTicks = new DateTime(1970, 1, 1).Ticks
    long timeOfCast;
    if (smiteReady && mob.Health < smitedamage)
    {
       timeOfCast = ((DateTime.UtcNow.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
       smite.Cast();
    }
    if (mob.Health < smitedamage + spelldamage)
    {
       Debug.WriteLine((DateTime.UtcNow.Ticks - epochTicks) / TimeSpan.TicksPerSecond) - timeOfCast)
       champSpell.Cast();
    }
