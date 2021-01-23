    //Label lblSalaries =new Label[4];
    //set properties of labels and add to frame.
    private void btnDisplay_Click(object sender, EventArgs e)
    {
    	    int count;
    	    decimal Raise;
    	    decimal Salary;
    	    decimal Sum;
    	    decimal Total;
    	for (count = 1; count <= 4; count++)
    	{
    	    Raise = Convert.ToDecimal(0.025);
    	    Salary = Convert.ToDecimal(txtSalary.Text);
    	    Sum = Salary * Raise;
    	    Total = Salary + Sum;
    	    lblSalaries[count-1].Text = Total.ToString("c");
    	}
    }
