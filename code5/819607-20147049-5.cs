    static void CharacterHealthChanged(Character characer)
    {
        if (!characer.IsAlive)
            Console.WriteLine("{0} was killed", characer.Name);
        else
            Console.WriteLine("{0}'s health reduced to {1}", 
                                    characer.Name, characer.Health);
    }
