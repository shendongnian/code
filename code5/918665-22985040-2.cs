    var newItems = new List<string>();
       foreach (object o in comboBoxKey.Items)
        { 
            String tmp1 = o.ToString();
            if (tmp1.IndexOf(tmp2) > 0)
            {
                newItems.Add(tmp1);
            }
        }
    comboBoxkey.DataSource = newItems;
