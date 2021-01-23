    if (!string.IsNullOrWhiteSpace(s))
    {
        string integerPart = s.Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0])[0];
        string[] groups = integerPart.Split(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator[0]);
        int maxGroupSize = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSizes.Max();
        for (int i = 0; i < groups.Length; i++)
        {
            //the first group can be any size that's less than or equal to the max groupsize
            //any other group has to be a size that's allowed in NumberGroupSizes
            if (!((i == 0 && groups[i].Length <= maxGroupSize)
                || CultureInfo.CurrentCulture.NumberFormat.NumberGroupSizes.Contains(groups[i].Length)))
            {
                throw new InvalidCastException(String.Format("Cannot convert {0} to Nullable<{1}>", s, typeof(T).Name));
            }
        }
        Type type = typeof(T);
        MethodInfo parseMethod = type.GetMethod("Parse", new[] { typeof(string), typeof(NumberStyles) });
        if (parseMethod != null)
        {
            result = (T)parseMethod.Invoke(null, new object[] { s, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands });
        }
    }
