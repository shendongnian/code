    private void FillComboBox()
    {
        comboBox.Items.Clear();
        List<Product> proList = getProducts();
        for (int i = 0; i < proList.Count; i++)
        {
            comboBox.Items.Add(proList[i]);
        }
    }
