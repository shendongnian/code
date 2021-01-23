    public bool Prop1
    {
        get { return this.myValue.HasValue; }
        // HACK: Do nothing in the set. It is only present to enable XML serialization.
        private set { }
    }
