    public string PercentageDisplay
    {
      get { return decimalValue.ToString("{0:F3}"); }
    }
    ///
    txtPercant.Text = PercentageDisplay;
