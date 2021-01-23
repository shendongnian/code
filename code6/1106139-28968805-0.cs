    T Max(IEnumerable<T> list)
    {
        var first = list.First();    
        var tail = list.Skip(1);
        {
          if (!tail.Any())
            return first;
        }
        var maxTail = Max(tail);
        return maxTail > first ? maxTail : first; 
    }
