        private void OnMouseMenuCut(object sender, EventArgs e)
        {
            var sPoint = rtbScript.SelectionStart;
            var text = rtbScript.SelectedText;
            rtbScript.Cut();
            Clipboard.SetText(text.Replace("\n", "\r\n"));
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
            rtbScript.SelectionStart = index + Clipboard.GetText().Length;
        }
