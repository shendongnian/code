    List<int[]> MyListOfArrays = new List<int[]>(); 
    range = xlApp.get_Range("NamedRange");  
    values = (object[,])range.Value2;
    for (int i = 0; i < values.GetLength(0); i++)
    {
        int[] temp = new int[30]; //<-- This will create a new array of ints, with each iteration of 1.
        for (int j = 0; j < values.GetLength(1); j++)
        {
            temp[j] = Convert.ToInt32(values[i + 1, j + 1]);  
        }
        MyListOfArrays.Add(temp);
    }
