    public void SetAllButtonTexts(string btnText)
    {
        foreach (var control in this.Controls.OfType<Button>())
        {
            (control).Text = btnText;
        }
    }
