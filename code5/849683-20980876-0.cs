    DateTime MyStDate;
    if (string.IsNullOrWhiteSpace(this.txtStartDate.Text))
    {
         MyStDate = Convert.ToDateTime(this.txtStartDate.Text);
    }
