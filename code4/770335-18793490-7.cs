    void Main()
    {
        Factory.Create(new BDef());
        Factory.Create<B, BDef>(new BDef());
        Factory.CreateAlternate<B, BDef>(new BDef());
    }
