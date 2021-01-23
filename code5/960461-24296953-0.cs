    private static string ConcatArray(string[] values, int totalLength)
    {
        string dest = FastAllocateString(totalLength);
        int destPos = 0;
        for (int i = 0; i < values.Length; i++)
        {
            FillStringChecked(dest, destPos, values[i]);
            destPos += values[i].Length;
        }
        return dest;
    }
