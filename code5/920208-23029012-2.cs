    public static void UnionSpecialWith(this HashSet<LogEvent> source,
                                        List<LogEvent> given,
                                        IEqualityComparer<LogEvent> comparer)
    {
        List<LogEvent> original = new List<LogEvent>(source);
        List<LogEvent> second = given.Condense(comparer);
    
        foreach (LogEvent logEvent in second)
        {
            if (original.Contains(logEvent, comparer))
            {
                int index = original.FindIndex(x => comparer.Equals(x, logEvent));
                original[index].filesAndLineNos
                               .MergeFilesAndLineNos(logEvent.filesAndLineNos);
            }
            else
            {
                original.Add(logEvent);
            }
        }
        source.Clear();
        foreach (var item in original)
        {
            source.Add(item); 
        }
    }
