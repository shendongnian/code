    private String ConvertRtfToText()
    {
        System.Windows.Forms.RichTextBox rtfBox = new System.Windows.Forms.RichTextBox();
        rtfBox.Rtf = this.rtfData;
        return rtfBox.Text;
    }
