    List<string> totalPrices = new List<string>();
    foreach (ListViewItem item in lstVw_queues.Items)
    {
                var totalPrice = item.SubItems[2];
                totalPrices.Add(totalPrice.ToString());
    }
