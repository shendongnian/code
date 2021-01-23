    public static string Concat(params object[] args)
        {
          if (args == null)
            throw new ArgumentNullException("args");
          string[] values = new string[args.Length];
          int totalLength = 0;
          for (int index = 0; index < args.Length; ++index)
          {
            object obj = args[index];
            values[index] = obj == null ? string.Empty : obj.ToString();
            if (values[index] == null)
              values[index] = string.Empty;
            totalLength += values[index].Length;
            if (totalLength < 0)
              throw new OutOfMemoryException();
          }
          return string.ConcatArray(values, totalLength);
        }
