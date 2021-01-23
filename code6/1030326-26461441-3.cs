    StringBuilder sb = new StringBuilder(s2);
    foreach (char ch in s1)
    {
        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] == ch)
            {
                sb.Remove(i, 1);
                break;
            }
        }
    }
    return sb.ToString();
