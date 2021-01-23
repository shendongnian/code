    protected void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
    {
            HtmlMeta tag = new HtmlMeta();
            tag.HttpEquiv = "refresh";
            if (chkAutoRefresh.Checked)
            {
                tag.Content = "your content";
            }
            else
            {
                tag.Content = "";
            }
            Header.Controls.Add(tag);
    }
