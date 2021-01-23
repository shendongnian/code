    private void buttonCalc_Click(object sender, EventArgs e)
    {
    double dinnerPrice = Convert.ToDouble(minPrice.Text);
    double tipRate;
    double tip;
    double maxRate = Convert.ToDouble(maxTax.Text);
    double lowRate = Convert.ToDouble(minTax.Text);
    double minDinner = Convert.ToDouble(minPrice.Text);
    double maxDinner = Convert.ToDouble(maxPrice.Text);
    const double TIPSTEP = 0.05;
    const double DINNERSTEP = 10.00;
    tipRate = lowRate;
    label1.Text = "";
    label6.Text = "";
    label7.Text = "";
    for (tipRate = lowRate; tipRate <= maxRate; tipRate += TIPSTEP)
        label1.Text = label1.Text + String.Format(" {0, 8}", tipRate.ToString("F"))+"\t";\\Use Tab here for proper spacing
    label1.Text = label1.Text + String.Format("{0, 8}", tipRate.ToString("C"))+"\t";//Use Tab here for proper spacing
    const int NUM_DASHES = 50;
    for (int x = 0; x < NUM_DASHES; ++x) ;//Instead of this loop use static dashes like this.
