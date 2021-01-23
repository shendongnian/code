    class SomeValues
    {
        public double _A = 10;
        public double _B = 20;
        public FieldInfo[] GetMyFields()
        {
            return GetType().GetFields();
        }
    }
