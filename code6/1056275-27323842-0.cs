    int selectedIndex;
    for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
    {
    selectedIndex=listBox1.SelectedIndices[i];
    liststa.Remove(listBox1.Items[selectedIndex].ToString()); 
    listBox1.Items.RemoveAt(selectedIndex);
    }
