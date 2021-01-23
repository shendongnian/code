    class AnimalOptions
    {
        public enum Dogs
        {
            Mastiff,
            Bulldog
        }
        public enum Cats
        {
            Manx,
            Tiger
        }
    }
    Type t = typeof(AnimalOptions);
    Type enumType = t.GetNestedType("Dogs");
    Populate(enumType);
