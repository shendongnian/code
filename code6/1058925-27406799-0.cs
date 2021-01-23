    struct CardEffect
    {
        public string CardGlyph;
        public int MinValue;
        public int MaxValue;
    }
    ... load from XML file or some other location and load into ...
    public Dictionary<string, CardEffect> cardValues;
