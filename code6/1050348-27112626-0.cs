    [STAThread]
    public static void Main(string[] args)
    {
        //string input = "<table><tr><td>Hello, world!</td></tr></table>";
        string input=Clipboard.GetText();
        ConvertToRTF(input);
        string text=Clipboard.GetText(TextDataFormat.Rtf);
        Clipboard.SetText(text,TextDataFormat.Rtf);
    }
    public static void ConvertToRTF(string html)
    {
        RichTextBox rtbTemp = new RichTextBox();
        WebBrowser wb = new WebBrowser();
        wb.Navigate("about:blank");
        wb.Document.Write(html);
        wb.Document.ExecCommand("SelectAll", false, null);
        wb.Document.ExecCommand("Copy", false, null);
        rtbTemp.SelectAll();
        rtbTemp.Paste();
        rtbTemp.Copy();
    }
