    public Form1()
    {
        var poss = (new [] { "A", "B", "C", "D", "E", "F", "G", "H" })
                   .OrderBy(c => RandomNumber())
                   .GetEnumerator();
    }
    private IEnumerator<string> selections;
    private Random rnd = new Random();
    private void selectButton_Click(object sender, EventArgs e)
    {
        if (selections.MoveNext())
            outputRichTextBox.Text = selections.Current;
        else
            outputRichTextBox.Text = "all have been selected";
    }
    private int RandomNumber()
    {
        int num = rnd.Next();
        return num;
    }
