    var tagIndices = new Dictionary<string,  IList<int>>();
    foreach (string tag in tagsCT)
    {
        IList<int> indices;
        if (!tagIndices.TryGetValue(tag, out indices))
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
