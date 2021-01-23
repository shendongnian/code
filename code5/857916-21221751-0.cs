    public static int GetIndexDifference(IDictionary source, IDictionary target, object key)
    {
        int index1=0, index2=0;
        int currentPosition = 1;
        foreach (var element in source.Keys)
        {
            if (element.Equals(key))
            {
                index1 = currentPosition;
                break;
             }
             currentPosition++;
         }
         currentPosition = 1;
         foreach (var element in target.Keys)
         {
             if (element.Equals(key))
             {
                index2 = currentPosition;
                break;
             }
             currentPosition++;
         }
            return Math.Abs(index1 - index2);
    }
