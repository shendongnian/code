    public void SetAllButtonTexts(string btnText, string tagText = "")
    {
        foreach (var control in this.Controls.OfType<Button>()
            .Where(b => string.IsNullOrEmpty(tagText) 
                || (b.Tag != null && b.Tag.Equals(tagText))))
        {
            (control).Text = btnText;
        }
    }
