    double[] two = { 2 };
    int count2 = 0;
    private void btnChoose_Click(object sender, EventArgs e)
    {
        double chose = number.Next(1, 7);
        txtnumber.Text = chose.ToString();
        count2 = count2 + System.Convert.ToInt32(two.Contains(chose));
        txtnumber2.Text = count2.ToString();
    }
