    Stopwatch stopwatch = new Stopwatch();
    if (smiteReady && mob.Health < smitedamage)
    {
       stopwatch.Start();
       smite.Cast();
    }
    if (mob.Health < smitedamage + spelldamage)
    {
       stopwatch.Stop();
       Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
       champSpell.Cast();
    }
