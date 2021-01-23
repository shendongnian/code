    public void eatSomethingt(IEatable eatable)
    {
        var eatItem = items.OfType<IEatable>.Where( item => item.Name == eatable.Name).FirstOrDefault();
        if (eatItem == null)
            return;
        life = life + eatItem.amountHealed;
        Console.WriteLine(Name + " ate " + eatable.name); //Same ERROR here.
        items.Remove(i);
     
    }
