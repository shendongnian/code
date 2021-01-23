    this.PreviewTextInput += OnButtonPreviewTextInput;
    ...
    void OnButtonPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if ("äöüÄÖÜß".Contains(e.Text))
        {
            Debug.WriteLine("German text entered");
        }
        else if (e.Text.Any(c=>0x0400 <= c && c <= 0x4FF))
        {
            Debug.WriteLine("Cyrillic text entered");
        }
    }
