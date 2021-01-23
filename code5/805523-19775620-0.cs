    private async void button1_Click(object sender, EventArgs args)
    {
        foreach (Color b in new ColorConverter().GetStandardValues())
        {
            button1.BackColor = b;
            await Task.Delay(200);
        }
    }
