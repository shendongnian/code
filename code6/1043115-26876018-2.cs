        StringBuilder sb = new StringBuilder();
        for (int i = 0, length = Math.Max(izmers1.Length, izmers2.Length); i < length; i++)
        {
            if (i < izmers1.Length) sb.Append(izmers1[i]);
            if (i < izmers2.Length) sb.Append(izmers2[i]);
        }
        var s = sb.ToString();
