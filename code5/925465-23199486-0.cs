    public IEnumerable<OilCategory> Ancestors
    {
        get
        {
            OilCategory current = this;
            while (current != null)
            {
                yield return current;
                current = current.Parent;
            }
        }
    }
