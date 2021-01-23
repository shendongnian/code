    StringBuilder a = new StringBuilder();
    a.Append("The items you purchased are:\r\n\r\n");
    foreach (var item in lbxItemBought.Items)
    {
        a.Append(item.ToString());
    }
    a.Append("\r\nYour total price was:");
    a.Append(lblLastCheckout.Text);
    tbxReceipt.Text = a.ToString();
