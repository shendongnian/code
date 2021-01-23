    public void eat(this Player p,iEatable food)
    {
        Console.WriteLine(p.Name + " Ate the " + food.name);
        p.life = p.life + food.amountHealed;
    }
