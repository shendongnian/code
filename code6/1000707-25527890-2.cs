    public static class IsEqual
    {
        public static OneOfValuesConstraint ToAny(ICollection expected)
        {
            return new OneOfValuesConstraint(expected);
        }
    }    
