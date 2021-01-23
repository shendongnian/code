    private void HomePage_Click(object sender, EventArgs e)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URLInput.Text);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader sr = new StreamReader(response.GetResponseStream());
        richTextBox1.Text = sr.ReadToEnd();
    }
    private void ChangeHomeToolStripMenuItem_Click(object sender, EventArgs e)
    //this is menu item to call 
    {
        using(Home h = new Home())
        {
            h.ShowDialog();
            var homePageUrl = h.getHomePage();
            if (string.IsNullOrEmpty(homePageUrl))
                return;
            URLInput.Text = homePageUrl;
        }
    }
