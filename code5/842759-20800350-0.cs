    private double SavingAmount
    {
        get
        {
            double priceSavingAmount;
            // Add some synchronization if required
            if (!HttpContext.Current.Items.Contains("Saving"))
            {
                priceSavingAmount = FromService();
                HttpContext.Current.Items.Add("Saving", priceSavingAmount);
            }
            else
                priceSavingAmount = (double)HttpContext.Current.Items("Saving");
            return priceSavingAmount;
        }
    }
