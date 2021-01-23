    StringBuilder sb = new StringBuilder();
    for (int i = 1; i < s.Length - 1; i += 4)
    {
        sb.Append(s.Substring(i, 2));
    }
