    string str = string.Empty;
    int i = 0, j = 0;
    while (i < array.Length && j > -1)
    {
        j = Array.FindIndex(array, i, b => controlCodes.ContainsKey(b));
        if (j > -1) 
        {
            if (j > i)
            {
                str += Encoding.ASCII.GetString(array, i, j - i);
            }
            
            str += controlCodes[array[j]];
            i = j + 1;
        }
        else 
        {
            str += Encoding.ASCII.GetString(array, i, array.Length - 1);
        }
    }
    
    return str;
