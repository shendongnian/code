    public void eatSomethingt(Ieatable eatable)
    {
        foreach (IEatable i in items.OfType<IEatable>() ) //Go through every item in the players backpack that can be eaten.
        {
            if(i is Items) // is has a name.
            {    
                Ieatable k = i as Ieatable;
                Console.WriteLine(Name + " ate " + k.name); //Same ERROR here.
                life = life + k.amountHealed;
                items.Remove(i);
                break;
            }
        }
    }
