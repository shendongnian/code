    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        ProperName item =  (ConversionOperator) obj.ToString();
        return FullName == item.FullName
            && MiddleNameOptions == item.MiddleNameOptions
            && DisplayOptions == item.DisplayOptions;
    }
