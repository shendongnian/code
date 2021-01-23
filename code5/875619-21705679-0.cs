    void Chart_CustomDrawAxisLabel (object sender, CustomDrawAxisLabelEventArgs e)
      {
        AxisBase axis = e.Item.Axis;
        if(axis.NumericOptions.Format == NumericFormat.Currency)
          {
            decimal value = 0.00M;
            e.Item.Text = decimal.TryParse(e.Item.AxisValue.ToString(),
                                            out value)
                             ? value.ToString("C0", _culture)
                             : e.Item.AxisValue.ToString();
          }
      }
