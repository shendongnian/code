    private void btnDisplay_Click(object sender, EventArgs e)
    {
        decimal salary = Convert.ToDecimal(txtSalary.Text);
        decimal raise = 0.025m;
        decimal total = 0;
        decimal previous = salary;
        listBox1.Items.Add("Start: {0:N2}", salary);
        for (int year = 1; year <= 4; year++)
        {
            decimal sum = previous * (1 + raise);
            previous = sum;
            total += sum;
            listBox1.Items.Add("Year {0}: {1:N2}", year, sum);
        }
        listBox1.Items.Add("Total: {0:N2}", total);
    }
