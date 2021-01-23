    var tagIndices = new Dictionary<string,  IList<int>>();
    foreach (string tag in tagsCT)
    {
        IList<int> indices;
        if (tagIndices.TryGetValue(tag, out indices))
            continue; // to prevent the same indices on duplicate tags, you could also use a HashSet<string> instead of the array
        else
        {
            indices = new List<int>();
            tagIndices.Add(tag, indices);
        }
        int index = text.IndexOf(tag);
        while (index >= 0)
        {
            indices.Add(index);
            index = text.IndexOf(tag, index + 1);
        }
    }
