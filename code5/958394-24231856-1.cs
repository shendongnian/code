    private void btnDisplay_Click(object sender, EventArgs e)
    {
        decimal salary = Convert.ToDecimal(txtSalary.Text);
        decimal raise = 0.025d;
        decimal total = 0;
        decimal previous = salary;
        for (int year = 1; year <= 4; year++)
        {
            decimal sum = previous * (1 + raise);
            previous = sum;
            total += sum;
        }
        label2.Text = total.ToString("c");
    }
