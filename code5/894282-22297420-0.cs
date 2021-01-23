    private int RecursiveIteration(GridFieldCollection field)
    {
        int count = 0;
    
        for (int i = 0; i < field.Count ; i++)
        {
            if (field[i].GetType() == typeof(GroupField))
            {
                count += RecursiveIteration((field[i] as GroupField).Columns);
            }
            count++;
        }
    
        return count;
    }
