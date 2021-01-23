    private void txtMikeWater_TextChanged(object sender, EventArgs e)
    {
        int amount;
        if (int.TryParse(txtMikeWater.Text, out amount))
        {
            txtPattiWater.TextChanged -= txtPattiWater_TextChanged;
            txtPattiWater.Text = (water - amount).ToString();
            txtPattiWater.TextChanged += txtPattiWater_TextChanged;
        }
    }
    private void txtPattiWater_TextChanged(object sender, EventArgs e)
    {
        int amount;
        if (int.TryParse(txtMikeWater.Text, out amount))
        {
            txtMikeWater.TextChanged -= txtMikeWater_TextChanged;
            txtMikeWater.Text = (water - amount).ToString();
            txtMikeWater.TextChanged += txtMikeWater_TextChanged;
        }
    }
