    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        string IDs = ID.Text;
        new System.Threading.Thread(() =>
        {
            string[] eachIDs = Regex.Split(IDs, "\n");
            foreach (var eachID in eachIDs)
            {
                getContent(eachID);               
                titleBox.BeginInvoke((Action) delegate { titleBox.Text = "Done"; });  
            }
        }).Start();
    }
    private void getContent(string value)
    {
        label1.BeginInvoke((Action) delegate { label1.Text = value; });        
        Thread.Sleep(5000);
    }
