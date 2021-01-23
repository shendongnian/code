    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < flatListBox.Items.Count; i++)
    {
        sb.AppendLine(flatListBox.Items[i].ToString());
    }
    File.WriteAllText("SortedFlats.txt"), sb.ToString());
