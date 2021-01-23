    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        var bytes = new byte[] { 7, 0, 0x6c, 0 };
        string s = Encoding.ASCII.GetString(bytes);
        this.label1.Text = s;
        Debug.Assert(this.label1.Text == s);
    }
