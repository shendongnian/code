    public decimal CashEntered { get; private set; }
    private void ok_btn_Clicked
    {
        decimal value;
        if (Decimal.TryParse(cashEntered_txt.Text, out value))
        {
            CashEntered = value;
            DialogResult = DialogResult.OK;
        }
        else
        {
            MessageBox.Show("Please enter a valid amount of cash tendered. E.g. '5.50'");
        }
    }
}
