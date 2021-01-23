    Label[] lblSalaries = new Label[4];
    private void CreateControls()
    {
            
            int x = 0, y = 10;
            for (int i = 0; i < lblSalaries.Length;i++ )
            {
                lblSalaries[i] = new Label();
                x += 60;
                lblSalaries[i].Size = new System.Drawing.Size(50, 30);
                lblSalaries[i].Location = new System.Drawing.Point(x,y);
                Controls.Add(lblSalaries[i]);
            }
    }
    private void btnDisplay_Click(object sender, EventArgs e)
    {
    	    int count;
    	    decimal Raise;
    	    decimal Salary;
    	    decimal Sum;
    	    decimal Total;
        CreateControls();
    	for (count = 1; count <= 4; count++)
    	{
    	    Raise = Convert.ToDecimal(0.025);
    	    Salary = Convert.ToDecimal(txtSalary.Text);
    	    Sum = Salary * Raise;
    	    Total = Salary + Sum;
    	    lblSalaries[count-1].Text = Total.ToString("c");
    	}
    }
