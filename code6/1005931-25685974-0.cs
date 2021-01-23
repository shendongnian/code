    public static class StatusedValue
    {
        public static StatusedValue<T> Create<T>(T value, bool isValid = true) where T: struct
        {
            return new StatusedValue<T>(value, isValid);
        }
    }
