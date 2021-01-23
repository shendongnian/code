    foreach (var item in this.Items)
    {
          flowLayoutPanel1.Controls.Add(item);
          item.LinkClicked += item_LinkClicked;
    }
    void item_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
          MessageBox.Show(((item)sender).Name);
    }
