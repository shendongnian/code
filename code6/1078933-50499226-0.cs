    /// <summary>
    /// Merges the specified NameValueCollection arguments into a single NamedValueCollection.
    /// </summary>
    /// <param name="args">An array of NameValueCollection to be merged.</param>
    /// <returns>Merged NameValueCollection</returns>
    /// <remarks>
    /// Returns an empty collection if args passed are null or empty.
    /// </remarks>
    static NameValueCollection Merge(params NameValueCollection[] args)
    {
        NameValueCollection combined = new NameValueCollection();
    
        if (args == null || args.Length == 0)
        {
            return combined;
        }
    
        NameValueCollection current = null;
        for (int i = 0; i < args.Length; i++)
        {
            current = args[i];
    
            if (current != null && current.Count > 0)
            {
                combined.Add(current);
            }
        }
    
        return combined;
    }
