    if(line.Length > 100)
    {
        StringBuilder sb = new StringBuilder(line.Length + line.Length/2);
        for(int i=0; i < line.Length; i++)
        {
            sb.Append(line[i]);
            if (i % 2 == 1 && i < line.Length-1)
                sb.Append(' ');
        }
        return sb.ToString();
    }
    // else your approach
