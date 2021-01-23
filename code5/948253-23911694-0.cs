    enum AgeUnits
    {
        Days,
        Months,
        Years
    }
    
    class Age
    {
        public int Value { get; private set; }
        public AgeUnits Units { get; private set; }
        public Age(int value, AgeUnits ageUnits)
        {
            Value = value;
            Units = ageUnits;
        }
    }
