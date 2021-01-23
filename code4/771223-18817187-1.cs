    public void eat(this Player p,IEdible food)
    {
        Console.WriteLine(p.Name + " Ate the " + food.name);
        p.life = p.life + food.amountHealed;
    }
