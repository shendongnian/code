    public override string ToString()
    {
        if ( Debugger.IsAttached )
        {
            return this.GetType().Name + ": " + this.Title; // or something else.
        }
        // The rest of your ToString implementation
    }
