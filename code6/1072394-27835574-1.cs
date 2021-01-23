    int index = i + k;
    if (index >= Lines_Array.Length)
    {
        break;
    }
    else
    {
        var line = Lines_Array[index];
        if (string.IsNullOrEmpty(line))
        {
            // break; or whatever you need to ...
        }
        else
        {
            // if (line.Substring ... ) and so on
        }
    }
