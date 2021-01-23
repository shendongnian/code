    public static IEnumerable<T> TakeAndRemove<T>(Queue<T> queue, int count)
    {
       count = Math.Min(queue.Count, count);
       for (int i = 0; i < count; i++)
          yield return queue.Dequeue();
    }
