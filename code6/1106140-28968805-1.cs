    T Max<T>(IEnumerable<T> list)where T: IComparable<T>
    {
        var first = list.First();    
        var tail = list.Skip(1);
        {
          if (!tail.Any())
            return first;
        }
        var maxTail = Max(tail);
        return maxTail.CompareTo(first) > 0 ? maxTail : first; 
    }
