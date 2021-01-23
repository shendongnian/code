    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        string IDs = ID.Text;
        string[] eachIDs = Regex.Split(IDs, "\n");
        foreach (var eachID in eachIDs)
        {
            await getContent(eachID);
            titleBox.Text = "Done";
        }
    }
    private async Task getContent(string value)
    {
        label1.Text = value;
        await Task.Delay(5000);
    }
