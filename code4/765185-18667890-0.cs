    int window = (buffer.Length / maxWidth) + 1;
    
    for (int x = 0; x < buffer.Length; x += window)
    {
        double min = double.MaxValue;
        double max = double.MinValue;
        for (int j = 0; j < window; j++)
        {
            int index = x + j;
            if (index < buffer.Length)
            {
                double value = buffer[x+j];
                if (value < min)
                {
                    min = value;
                }
 
                if (value > max)
                { 
                    max = value;
                }
            }
        }
        list.Add(x, min);
        list.Add(x + (window - 1), max);
    }
            
