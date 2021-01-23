    private void pic1_MouseEnter(object sender, EventArgs e)
    {
    	pic1.MouseEnter -= pic1_MouseEnter;
    	pic1.MouseLeave -= pic1_MouseLeave;
    	
        pic1.Location = new Point(328, 300);
    	
    	pic1.MouseEnter += pic1_MouseEnter;
    	pic1.MouseLeave += pic1_MouseLeave;
    }
