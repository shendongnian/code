    private void btnRemoveItem_Click(object sender, EventArgs e)
    {
        int total = 0;
        foreach (ListViewItem item in lvCart.Items)
        {
           if (lvCart.Items[0].Selected)
            {
                total+=(int)lvCart.SelectedItems[0].SubItems[1].Text;//Add to total while romving
               lvCart.Items.Remove(lvCart.SelectedItems[0]);
               //total += Convert.ToInt32(item.SubItems[1].Text);
            }
        }
          rtbTcost.Text = total.ToString();
       }
