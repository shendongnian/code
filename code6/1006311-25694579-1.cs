    public void SetAllButtonTexts(string text)
    {
        foreach (var control in this.Controls.OfType<Button>())
        {
            (control).Text = text;
        }
    }
