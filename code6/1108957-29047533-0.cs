    // Find the index of PT
    int ix = TagList.FindIndex(x => x.FieldTag == "PT");
    // index found
    if (ix != -1)
    {
        // Check that index + 1 < the length of the List
        if (ix + 1 < TagList.Count)
        {
            var position = TagList[ix + 1]; // Add 1
        }
    }
