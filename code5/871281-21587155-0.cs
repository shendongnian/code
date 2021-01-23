    public static Type InferType(List<string> samples)
    {
        Type stringType= typeof(string);
        Type intType = typeof(int);
        Type doubleType = typeof(double);
        List<Type> types = new List<Type>();
        for (int i = 0; i < samples.Count; i++)
        {
            int intRepresentation;
            double doubleRepresentation;
            if (int.TryParse(samples[i], out intRepresentation))
            {
                types.Add(intType);
            }
            else if (double.TryParse(samples[i], out doubleRepresentation))
            {
                types.Add(doubleType);
            }
            else
            {
                types.Add(stringType);
                break;
            }
        }
        return types.Any(e => e == stringType) ? stringType :
            types.Any(e => e == doubleType) ? doubleType :
            intType;
    }
