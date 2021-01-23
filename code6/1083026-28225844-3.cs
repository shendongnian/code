    /// <summary>
    /// Load the (indexed) Option's items into the CheckedListBox for display.
    /// Reset the Checked state for any previously checked.
    /// </summary>
    /// <param name="index"></param>
    private void LoadOptions(int index)
    {
      this.SourceIndex = index;
      this.checkedListBox1.Items.Clear();
      foreach (KeyValuePair<int, string> item in this.Options[index])
      {
        this.checkedListBox1.Items.Add(item);
      }
      foreach (int i in this.Checked[index])
      {
        this.checkedListBox1.SetItemChecked(i, true);
      }
    }
    /// <summary>
    /// The displayed Options are about to change.
    /// Save the currently displayed Option's checked item indices.
    /// </summary>
    private void SaveCheckedStates()
    {
      if (this.SourceIndex >= 0)
      {
        this.Checked[this.SourceIndex].Clear();
        foreach (int i in this.checkedListBox1.CheckedIndices)
        {
          this.Checked[this.SourceIndex].Add(i);
        }
      }
    }
