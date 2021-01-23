    private void btnRemoveItem_Click(object sender, EventArgs e)
    {
        int totalRemoved = 0;
        while (lvCart.SelectedItems.Count > 0)
        {
            totalRemoved += Convert.ToInt32(lvCart.SelectedItems[0].SubItems[1].Text);
            lvCart.Items.Remove(lvCart.SelectedItems[0]);
        } 
        _listTotal -= totalRemoved;
        rtbTcost.Text = _listTotal.ToString
    }
