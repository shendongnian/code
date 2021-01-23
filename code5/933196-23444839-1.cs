    sealed class German : Unicode
    {
        protected override string ToUpperCore(string text)
        {
            // Very naive implementation, just to provide an example
            return text.ToUpper().Replace("ß", "ẞ");
        }
    }
