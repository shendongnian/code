    private void OnMouseMenuCut(object sender, EventArgs e)
    {
        var sPoint = rtbScript.SelectionStart;
        var ePoint = rtbScript.SelectionLength;
        var text = rtbScript.SelectedText;
        rtbScript.SelectedText.Cut();
        //rtbScript.Text = rtbScript.Text.Remove(sPoint, ePoint);
        Clipboard.SetText(text.Replace("\n", "\r\n"));
        //rtbScript.Text = rtbScript.Text.Insert(sPoint, text);
        rtbScript.SelectionStart = sPoint;
    }
    private void OnMouseMenuCopy(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(rtbScript.SelectedText)) return;
        Clipboard.SetText(rtbScript.SelectedText.Replace("\n", "\r\n"));
    }
    private void OnMouseMenuPaste(object sender, EventArgs e)
    {
        if (!Clipboard.ContainsText()) return;
        var index = rtbScript.SelectionStart;
        rtbScript.SelectedText = Clipboard.GetText();
        rtbScript.SelectionStart = index ;
    }
