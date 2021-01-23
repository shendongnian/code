    public static string UpperCaseFirstLetter(this string value)
    {
        string result;
        if (value.Length > 0)
        {
            char[] array = value.ToCharArray();
            array[0] = char.ToUpper(array[0]);
            result = new string(array);
        }
        else
        {
            result = value;
        }
        return result;
    }
