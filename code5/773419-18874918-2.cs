    public Dictionary<string, int> data;
    
    private void textContainer_rtb_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            String abc = this.textContainer_rtb.Text.Split(' ').Last();
            chkWordRepeat(abc);
        }
    }
    public void chkWordRepeat(string wrd)
    {
        bool present = false;
        foreach (string key in data.Keys)
        if (wrd == key)
        {
            present = true;
            data[wrd]++;
        }
        if (!present)
                data.Add(wrd, 1);
    }
