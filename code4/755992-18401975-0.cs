    public delegate void ButtonClickedEvent(object sender);
    public event ButtonClickedEvent Form1ButtonClicked;
    private void button1_Click(object sender, EventArgs e)
    {
        if (Form1ButtonClicked != null)
        {
            Form1ButtonClicked(sender);
        }
    }
