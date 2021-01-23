    public static int IndexOf(Array array, object value, int startIndex, int count)
    {
        int num2;
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        if (array.Rank != 1)
        {
            throw new RankException(Environment.GetResourceString("Rank_MultiDimNotSupported"));
        }
        int lowerBound = array.GetLowerBound(0);
        if ((startIndex < lowerBound) || (startIndex > (array.Length + lowerBound)))
        {
            throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
        }
        if ((count < 0) || (count > ((array.Length - startIndex) + lowerBound)))
        {
            throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
        }
        if (TrySZIndexOf(array, startIndex, count, value, out num2))
        {
            return num2;
        }
        object[] objArray = array as object[];
        int num3 = startIndex + count;
        if (objArray != null)
        {
            if (value == null)
            {
                for (int i = startIndex; i < num3; i++)
                {
                    if (objArray[i] == null)
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int j = startIndex; j < num3; j++)
                {
                    object obj2 = objArray[j];
                    if ((obj2 != null) && obj2.Equals(value))
                    {
                        return j;
                    }
                }
            }
        }
        else
        {
            for (int k = startIndex; k < num3; k++)
            {
                object obj3 = array.GetValue(k);
                if (obj3 == null)
                {
                    if (value == null)
                    {
                        return k;
                    }
                }
                else if (obj3.Equals(value))
                {
                    return k;
                }
            }
        }
        return (lowerBound - 1);
    }
    
