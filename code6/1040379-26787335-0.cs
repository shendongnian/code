    private static void SetTextToLabels(string text, params Label[] labels)
    {
        foreach (var label in labels)
        {
            label.Text = text;
         }
    }
    
    // Use like this
    private void UpdateTextInLabels()
    {
        SetTextToLabels("SomeText", label1, label2, label3);
    }
