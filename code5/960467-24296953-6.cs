    public static string Concat(params string[] values)
    {       
        int totalLength = 0; // variable to calculate total length
        string[] strArray = new string[values.Length]; // second array
        for (int i = 0; i < values.Length; i++) // first loop
        {
            string str = values[i];            
            totalLength += strArray[i].Length;           
        }
        return ConcatArray(strArray, totalLength);
    }
    private static string ConcatArray(string[] values, int totalLength)
    {
        string dest = FastAllocateString(totalLength);
        int destPos = 0; // variable to calculate current position
        for (int i = 0; i < values.Length; i++) // second loop
        {
            FillStringChecked(dest, destPos, values[i]);
            destPos += values[i].Length;
        }
        return dest;
    }
