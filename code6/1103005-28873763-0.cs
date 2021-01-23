    private void lb_FRIENDS_SelectedIndexChanged(object sender, EventArgs e)
    {
       string srtItem = lb_FRIENDS.SelectedItem.ToString();
       label1.Text = strItem.Substring(0, strItem.IndexOf("|"));
       label2.Text = strItem.Substring(strItem.IndexOf("|")+1);
    }
