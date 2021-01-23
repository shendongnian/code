    protected void Button5_Click(object sender, EventArgs e)
    {
    	var semicolonSeparatedString = "";
    	var e1 = new employee() { name = "employeeName", email = "employeeEmail" };
    	for (int index = 0; index < lb2.Items.Count; index++)
    	{
    		//no need to add separator for the first item
    		if (index == 0) semicolonSeparatedString += lb2.Items[index];
    		else semicolonSeparatedString += ";" + lb2.Items[index];
    	}
    	//data formatted as single string and ready to be saved
    	e1.emp_skill = semicolonSeparatedString;
    	je.employee.AddObject(e1);
    	je.SaveChanges();
    }
