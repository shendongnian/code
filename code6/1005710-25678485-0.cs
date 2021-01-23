    if (ipQueryTextBox.Text != null)
    {
        searchErrorLabel.Visible = false;
        string addresses = ipQueryTextBox.Text;
        addresses = addresses.Replace(" ", "");
        addresses = addresses.Replace(",", "','");
        Session["addresses"] = addresses;
    }
