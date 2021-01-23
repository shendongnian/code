    var sample = new Dictionary<int, string>();
    data.SomeProperty.ForEach(f =>
    {
        string newText = f.Text, oldText;
        if (sample.TryGetValue(f.Id, out oldText))
        {
            newText = oldText + newText;
        }
        sample[f.Id] = newText;
    });
