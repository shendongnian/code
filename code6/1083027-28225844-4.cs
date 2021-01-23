    /// <summary>
    /// The index of which dictionary Options are being displayed in the CheckedListBox.
    /// </summary>
    public int SourceIndex { get; set; }
    /// <summary>
    /// The array which will contain 3 dictionaries filled with data.
    /// </summary>
    Dictionary<int, string>[] Options { get; set; }
    /// <summary>
    /// An array of 3 lists (corrosponding to the Options dictionaries)
    /// which will contain the indices of checked Options items.
    /// </summary>
    List<int>[] Checked { get; set; }
