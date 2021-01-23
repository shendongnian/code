    public void eatSomethingt(Healer healer)
    {
        foreach (Items i in items)
        {
            if (i is Ieatable && i.name == healer.name)
            {
                Ieatable k = i as Ieatable;
                Console.WriteLine(Name + " ate " + healer.name);
                life = life + k.amountHealed;
                items.Remove(i);
                break;
            }
        }
    }
