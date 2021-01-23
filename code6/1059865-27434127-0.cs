    public Convert(...)
    {
        return value.Equals(parameter);
    }
    public ConvertBack(...)
    {
        if ((bool)value)
           return parameter;
        else
           return Binding.DoNothing; //Not null!!!!
    }
