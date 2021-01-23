    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            DataBase db = new DataBase();
            foreach (var row in gridItems.Items.Cast<DataRowView>())
            {
                int count;
                if (!int.TryParse(comboBox1.Text, out count))
                {
                    // Log error
                }
                int b = (int) row["PropertyNameNotIndex"];
                int totalCount = count - b;
                int itemId = (int) row["ItemId"];
                db.DoCommand("update TotalItems set ItemNumbers='" + count.ToString() + "'where ItemName='" + a + "'");
            }
        }
        catch (Exception ex)
        {
            // Handle DB connection errors, etc
        }
    }
