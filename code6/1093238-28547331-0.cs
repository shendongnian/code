    private void Max_TextChanged(object sender, EventArgs e)
    {
         DateTime date = DateTime.Parse(Max.Text);
         if (date < DateTime.Parse(AvailableMax.Text))
         {
            formErrorProvider.SetError(this.Max, "The Date you entered is either out of range or an invalid format");
         }
         else
         {
            formErrorProvider.SetError(this.Max, string.Empty);
            ToDate.MaxDate = date;
            ToDate.Value = date;
         }
    }
