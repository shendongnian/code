    try
    {
        if(Lines_Array.Length != 0)
        {
            while (Lines_Array[i + k].Substring(2, 5).Trim() == "Groze")
            {
                bedensay++;
                k++;
            }
        }
    }
    catch (ArgumentOutOfRangeException) { }
