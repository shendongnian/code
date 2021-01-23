    public override string ToString()
    {
        return string.Format("{0} {1}",
            UserName,
            IsMod ? "(*)" : string.Empty);
    }
