    public bool Equals(MyObject other)
    {
        // BOOOM!!! StackOverflowException!
        // Equals will call operator== that will probably call
        // Equals back! and so on and so on.
        if (other == null)
        {
            return false;
        }
        return this.InnerEquals(other);
    }
