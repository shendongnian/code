    public void updateBalance(double amount, double fee, out double balance)
    {
        try
        {
            balance = amount * (1.0 + fee);
            if (balance < 0.0) balance = 0.0;
        }
        catch (Exception Ex)
        {
            System.Diagnostics.Debug.WriteLine(Ex.Message);
            throw Ex;
        }
    }
