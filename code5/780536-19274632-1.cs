    public IEnumerable SourceProperty
    {
        get
        {
            yield return new TextBlock(new Run("First"));
            yield return new TextBlock(new Run("Second"));
            yield return new TextBlock(new Run("Third"));
        }
    }
