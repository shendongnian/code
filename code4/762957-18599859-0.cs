    // HelperClass method
    public static void UpdateCommentLines(RichTextBox richTextBox)
    {
        List<string> commentLines = richTextBox.Lines.ToList();
    }
    // WinForm Code
    public void DoSomething()
    {
        HelperClass.UpdateCommentLines(this.richTextBox1);
    }
