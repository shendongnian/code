    protected void CalculateBtn_Click (object sender, EventArgs e)
    {
        int num1 = Int32.Parse(TB1.Text);
        int num2 = Int32.Parse(TB2.Text);
        int sum = num1+num2;
        SumTB.Text = sum.ToString();
    }
