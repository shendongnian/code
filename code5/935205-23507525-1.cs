    public Foo split(int amount)
    {
        int diff = this.amount - amount;
        this.amount = amount;
        List<Baar> baarsCopy = new List<Baar>(this.baars); //make a copy
        return new Foo(diff, baarsCopy); //pass the copy
    }
