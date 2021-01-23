    public void Attack(Dog theDog)
    {
        Console.WriteLine("{0} attacks {1}.", this.name, theDog.name);
        theDog.LoseHealth(5);
    }
    public void LoseHealth(int damage)
    {
        Console.WriteLine("{0} loses health!", name);
        this.health -= damage;
    }
    
