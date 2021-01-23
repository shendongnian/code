    public static double[] CopyFixedDoubleArray(this Data data)
    {
        unsafe
        {
            return new[] { data.Values[0], data.Values[1], data.Values[2] };
        }
    }
