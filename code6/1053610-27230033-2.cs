    string _searchText;
    protected void Button1_Click(object sender, System.EventArgs e)
    {
        _searchText = Server.HtmlEncode(TextBox1.Text);
        // do something with _searchText
    }
