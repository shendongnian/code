    public delegate void SetTextDelegate(string sText);
    private SetTextDelegate SetText = new SetTextDelegate(SetTextBoxText);
    private void SetTextBoxText(string sText)
    {
        tbStatus.Text = sText;
    }
