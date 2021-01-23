    public IEnumerable<VariableType> VariableTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(VariableType)).Cast<VariableType>();
            }
        }
