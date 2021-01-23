    public object this[int index]
    {
        get
        {
            // Alternative: remove the hard-coding, and fetch the properties
            // via reflection.
            switch(index)
            {
                // Note: property names changed to conform to .NET conventions
                case 0: return Id;
                case 1: return Name;
                case 2: return GoodGuy;
                default: throw new ArgumentOutOfRangeException("index");
            }
        }
    }
