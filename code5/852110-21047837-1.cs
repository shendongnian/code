    private void cmbDots_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            randomPaint(Convert.ToInt32(cmbDots.SelectedItem));
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
    }
