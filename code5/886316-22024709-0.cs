    /// <summary>
    /// Merges the incoming sorted streams of items into a single sorted stream of items, using the provided comparison function
    /// </summary>
    public static IEnumerable<T> MergeMany<T>(Comparison<T> comparison, params IEnumerable<T>[] collections)
    {
      var liveEnumerators = new PriorityQueue<IEnumerator<T>>((e1, e2) => comparison(e1.Current, e2.Current));
      // start each enumerator and add them to the queue, sorting by the current values.
      // Discard any enumerator that has no item
      foreach (var coll in collections)
      {
        var enumerator = coll.GetEnumerator();
        if (enumerator.MoveNext())
          liveEnumerators.Push(enumerator);
      }
      while (liveEnumerators.Any())
      {
        // pull an enumerator off the queue and yield its current item
        var enumerator = liveEnumerators.Pop();
        yield return enumerator.Current;
        // if it has more items, throw it back on the queue, sorting using its new current item.
        if (enumerator.MoveNext())
          liveEnumerators.Push(enumerator);
      }
    }
