    int count;
    Salary = Convert.ToDecimal(txtSalary.Text);
    for (count = 1; count <= 4; count++)
    {
        Salary * 0.025m;
    }
    label2.Text = Salary.ToString("c");
