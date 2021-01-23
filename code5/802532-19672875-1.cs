    private void btnCompute_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(txtXvalue.Text);
        int y = Convert.ToInt32(txtYvalue.Text);
        DesktopLocation = new Point(x, y);
    }
    
    private void xValue_TextChanged(object sender, EventArgs e)
    {
        int xValue =
            Convert.ToInt32(txtXvalue.Text);
    }
    
    private void yValue_TextChanged(object sender, EventArgs e)
    {
        int y =
            Convert.ToInt32(txtYvalue.Text);
    }
