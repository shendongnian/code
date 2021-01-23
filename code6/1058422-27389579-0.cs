    public void button_Click(object sender, EventArgs e)
    { 
        Button b = (Button)sender;
        if(b.BackColor == Color.LightSkyBlue)
        {
        b.BackColor = Color.ForestGreen;
        }
        else
        {
            b.BackColor = Color.LightSkyBlue;
        }
    }
