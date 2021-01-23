    dynamic values = ws.Range["F2", "AL" + (1 + noOfStudents)].Value2;
    
    int firstDimension = values.GetLength(0);
    int secondDimension = values.GetLength(1);
    double[,] array = new double[firstDimension, secondDimension];
    
    for (int i = 0; i < firstDimension; i++)
    {
        for (int j = 0; j < secondDimension; j++)
        {
            object value = values[i + 1, j + 1];
    
            if (value == null)
            { /* Report about a null value */ }
    
            if (value is double)
            {
                array[i, j] = (double)value;
            }
            else
            {
                if (!double.TryParse(value.ToString(), out array[i, j]))
                { /* Report about a wrong type */ }
            }
        }
    }
