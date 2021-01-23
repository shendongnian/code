    public void eatSomethingt(Healer item)
    {
        Console.WriteLine(Name + " ate " + item.name);
        life = life + item.amountHealed;
        items.Remove(item);
    }
