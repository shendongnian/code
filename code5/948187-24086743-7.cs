    // Assumes stMainText is of type Word.Range
    Word.Range styleRange;
    if (CheckBox1.Checked == true)
    {
        stMainText = AppendToRange(stMainText, "some text here, ", out styleRange);
        // Example styling of the inserted text below
        styleRange.Bold = 0;
        styleRange.Font.Name = "Verdana";
        styleRange.Font.Size = 20.0F;
    }
    
    if (CheckBox2.Checked == true)
    {
        stMainText = AppendToRange(stMainText, "some more text here, ", out styleRange);
        // Example styling of the inserted text below
        styleRange.Bold = -1;
        styleRange.Font.Name = "Times New Roman";
        styleRange.Font.Size = 10.0F;
    }
    
    if (CheckBox3.Checked == true)
    {
        stMainText = AppendToRange(stMainText, "and even more text here. ", out styleRange);
        // Add necessary styling here
    }
