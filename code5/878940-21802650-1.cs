    var newList = lvCart;
    foreach (ListViewItem item in lvCart.Items)
    {
        if (lvCart.Items[0].Selected)
        {
            newList.Items.Remove(lvCart.SelectedItems[0]);
            total += Convert.ToInt32(item.SubItems[1].Text);
        }
    }
