    if (url.IsMatch(urlText.Text) && name.IsMatch(nameText.Text) && price.IsMatch(priceText.Text))
    {
         itemListBox.Items.Add(nameText.Text);
         double item_Price = Convert.ToDouble(priceText.Text);
         items.Add(new Item(@itemURL.Text, itemName.Text, item_Price));
         nameText.Clear();
         priceText.Clear();
         urlText.Clear();
    }
