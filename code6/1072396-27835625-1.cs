    try
    {
        if(Lines_Array.Length != 0)
        {
            while (Lines_Array[i + k].Substring(2, 5).Trim() == "Groze")
            {
                if(Lines_Array.Length <= (i + k))
                {
                    bedensay++;
                    k++;
                }
            }
        }
    }
    catch (ArgumentOutOfRangeException) { }
