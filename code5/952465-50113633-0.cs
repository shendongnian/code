    public static void Reset(this StringReader reader)
    {
        reader.GetType()
              .GetField("_pos", BindingFlags.NonPublic | BindingFlags.Instance)
              .SetValue(reader, 0);
    }
