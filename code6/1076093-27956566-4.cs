    private void txtMikeWater_TextChanged(object sender, EventArgs e)
    {
        if (!textUpdatingFromCode)
        {
            int amount;
            if (int.TryParse(txtMikeWater.Text, out amount))
            {
                mikeExpenses.Water = amount;
                pattiExpenses.Water = totalExpenses.Water - mikeExpenses.Water;
                UpdateTextBoxes();
            }
        }
    }
    private void txtPattiWater_TextChanged(object sender, EventArgs e)
    {
        if (!textUpdatingFromCode)
        {
            int amount;
            if (int.TryParse(txtMikeWater.Text, out amount))
            {
                pattiExpenses.Water = amount;
                mikeExpenses.Water = totalExpenses.Water - pattiExpenses.Water;
                UpdateTextBoxes();
            }
        }
    }
