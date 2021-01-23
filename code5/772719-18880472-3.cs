    partial struct ValidPercent 
    {
        public static implicit operator Percent(ValidPercent vp)
        {
            return new Percent (vp.Value);
        }
        static partial void Partial_ValidateValue(decimal value)
        {
            if (value < 0M || value > 100M)
            {
                throw new ArgumentException ("value", "value is expected to be in the range 0..100");
            }
        }
    }
