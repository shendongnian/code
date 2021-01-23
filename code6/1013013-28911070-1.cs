    public static void SetProperties<TIn, TOut>(TIn input, TOut output, ICollection<string> includedProperties)
        where TIn : class
        where TOut : class
    {
        if ((input == null) || (output == null)) return;
        Type inType = input.GetType();
        Type outType = output.GetType();
        foreach (PropertyInfo info in inType.GetProperties())
        {
            PropertyInfo outfo = ((info != null) && info.CanRead)
                ? outType.GetProperty(info.Name, info.PropertyType)
                : null;
            if (outfo != null && outfo.CanWrite
                && (outfo.PropertyType.Equals(info.PropertyType)))
            {
                if ((includedProperties != null) && includedProperties.Contains(info.Name))
                    outfo.SetValue(output, info.GetValue(input, null), null);
                else if (includedProperties == null)
                    outfo.SetValue(output, info.GetValue(input, null), null);
            }
        }
    }
