    public static System.Collections.IEnumerable Power(int number, int exponent)
    {
        int result = 1;
        for (int i = 0; i < exponent; i++)
        {
            result = result * number;
            yield return result;
        }
    }
