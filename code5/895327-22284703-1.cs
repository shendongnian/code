        public enum OldEnum
        {
            One,
            Two,
            Three
        }
        public enum NewPart1
        {
            One,
            Two
        }
        public enum NewPart2
        {
            Three
        }
    [Obsolete("This method is intended to by used be previous versions")]
        public OldEnum GetEnum(someparameters here)
        {
            // Some processing here
            return OldEnum.One;
        }
        public NewPart1 GetEnum(someparameters here)
        {
            // Do something here
            return NewPart1.One;
        }
        public NewPart2 GetEnum(someparameters here)
        {
            // Do something here
            return NewPart2.Three;
        }
