    public static int CountIEnumerable (IEnumerable t)
    {
        var iterator = t.GetEnumerator();
        var max = int.MaxValue;
        int count = 0;
        while (iterator.MoveNext() && (count < max))
        {
            count++;
        }
    
        //OPTIONAL
        //if (count >= max)
        //{
           //   throw new Exception("Collection is too big");
        //}
        return count;
        }
