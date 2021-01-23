    List<string> listText = new List<string>();
    List<string> listValue = new List<string>();
    foreach (int index in ListBox1.GetSelectedIndices()) {
        listText.Add(ListBox1.Items[index].Text);
        listValue.Add(ListBox1.Items[index].Value);
    }
