    private void UpdateTextBoxes()
    {
        textUpdatingFromCode = true;
        txtPattiWater.Text = pattiExpenses.Water.ToString();
        txtMikeWater.Text = mikeExpenses.Water.ToString();
        // . . .
        // Continue for any other text boxes, including 
        // one that displays each person's total
        txtPattiTotal.Text = pattiExpenses.Total.ToString();
        txtMikeTotal.Text = mikeExpenses.Total.ToString();
        textUpdatingFromCode = false;
    }
