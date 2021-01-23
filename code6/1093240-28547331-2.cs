    private void Max_TextChanged(object sender, EventArgs e)
    {
         DateTime date;
         if (!DateTime.TryParse(Max.Text, out date))
         {
            formErrorProvider.SetError(this.Max, "The Date you entered is in invalid format");
         }
         else if (date > DateTime.Parse(AvailableMax.Text))
         {
            formErrorProvider.SetError(this.Max, "The Date you entered is out of range");
         }
         else
         {
            formErrorProvider.SetError(this.Max, string.Empty);
            ToDate.MaxDate = date;
            ToDate.Value = date;
         }
    }
