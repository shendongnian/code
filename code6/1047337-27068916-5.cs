    internal override object ConvertProposedValue(object value)
    {
        object result;
        bool success = ConvertProposedValueImpl(value, out result);
        {
            result = DependencyProperty.UnsetValue;
            ...
        }
        return result;
    }
    private bool ConvertProposedValueImpl(object value, out object result)
    {
        result = GetValuesForChildBindings(value);
        object[] values = (object[])result;
        int count = MutableBindingExpressions.Count;
        bool success = true;
        // use the smaller count
        if (values.Length < count)
            count = values.Length;
        for (int i = 0; i < count; ++i)
        {
            value = values[i];
            ...
            if (value == DependencyProperty.UnsetValue)
                success = false; // if any element is UnsetValue, conversion fails
            values[i] = value;
        }
        result = values;
        return success;
    }
