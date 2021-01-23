    /// <summary>
    /// Sorts the collection.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the collection.</typeparam>
    /// <param name="collection">The collection to sort.</param>
    /// <param name="comparison">The comparison used for sorting.</param>
    public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison = null)
    {
        var sortableList = new List<T>(collection);
        if (comparison == null)
            sortableList.Sort();
        else
            sortableList.Sort(comparison);
        for (var i = 0; i < sortableList.Count; i++)
        {
            var oldIndex = collection.IndexOf(sortableList[i]);
            var newIndex = i;
            if (oldIndex != newIndex)
                collection.Move(oldIndex, newIndex);
        }
    }
