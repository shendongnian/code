    private void btnDisplay_Click(object sender, EventArgs e)
    {
        decimal salary = Convert.ToDecimal(txtSalary.Text);
        decimal raise = 0.025d;
        decimal total = 0;
        decimal previous = salary;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Start {0:N0}\n", salary);
        for (int year = 1; year <= 4; year++)
        {
            decimal sum = previous * (1 + raise);
            sb.AppendFormat("\nYear {0}: {1:N0}", year, sum);
            previous = sum;
            total += sum;
        }
        MessageBox.Show(sb.ToString());
        label2.Text = total.ToString("c");
    }
