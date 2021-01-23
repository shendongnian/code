    private void btnCompute_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(txtXvalue.Text);
        int y = Convert.ToInt32(txtYvalue.Text);
        DesktopLocation = new Point(Math.Abs(x), Math.Abs(y));
    }
    
