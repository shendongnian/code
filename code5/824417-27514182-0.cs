    private void timer1_Tick(object sender, EventArgs e)
    {
        if (tickcolor) txtAno.BackColor = Color.Red;
        if (!tickcolor) txtAno.BackColor = Color.White;
        tickcolor = !tickcolor;
    }
    private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
    {
        timer1.Stop();
        txtAno.BackColor = Color.White;
    }
