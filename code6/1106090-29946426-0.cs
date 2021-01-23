    List <int> indices = new List<int>();
    if (listBoxGridColumns.SelectedIndices.Count > 1)
    {
        foreach (int index in listBoxGridColumns.SelectedItems)
        {
            indices.Add(index);
        }
        indices.Sort();
        int smallest = indices.First();
        int biggest = indices.Last();
        for(int i = smallest; i <= biggest; i++)
        {
            listBoxGridColumns.SetSelected(i, True);
        }
    }
