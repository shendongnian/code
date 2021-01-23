    public void HeroStateManager()
    {
        Mage mage = new Mage();
        // Console.ReadLine(); what was this? pausing for debugging?
        if (HeroClass() == "Mage")
        {
            int[] stats = new int[3];
            Mage.Stats(stats);
            Console.WriteLine("You have the following stats:");
            Console.WriteLine("Intel:   {0}", stats[0]);
            Console.WriteLine("Str:     {0}", stats[1]);
            Console.WriteLine("Dex:     {0}", stats[2]);
        }
    }
