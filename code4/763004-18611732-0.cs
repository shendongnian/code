    public static IEnumerable<T> TakeAndRemove<T>(Queue<T> queue, int count)
    {
       for (int i = 0; i < Math.Max(queue.Count, count); i++)
          yield return queue.Dequeue();
    }
