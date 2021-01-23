    protected void totClsInput_onfocusOut(object sender, EventArgs e)
    {
        this.CalculatePercent();
    }
    protected void attendedClsInput_onfocusOut(object sender, EventArgs e)
    {
        this.CalculatePercent();
    }
    private void CalculatePercent()
    {
        int cls, atnd, prcent;
        cls = int.Parse(totClsInput.Text);
        atnd = int.Parse(attendedClsInput.Text);
        prcent = atnd * 100 / cls;
        attndPercentageInput.Text = prcent.ToString();
    }
