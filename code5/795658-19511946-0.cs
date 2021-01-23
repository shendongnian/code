    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        string s = ((char)7).ToString();
        this.label1.Text = s;
        Debug.Assert(this.label1.Text == s);
    }
