        datset2 = new DataTable();
        sda2.Fill(datset2);
        if (datset2.Rows.Count == 0)
        {
            // I'm assuming "product_item" is a string
            datset2.Rows.Add("No items found");
        }
