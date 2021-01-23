    DateTime inputDate;
    
    if (DateTime.TryParseExact(this.textBox1.Text, "ddMMyy", null, DateTimeStyles.None, out inputDate))
    {
        var minDate = DateTime.Today.AddYears(-2);
        var maxDate = DateTime.Today.AddMonths(1);
        var A = inputDate >= minDate;
        var B = inputDate <= maxDate;
    
        MessageBox.Show(string.Format("input: {1:d}{0}min: {2:d}{0}max: {3:d}{0}A: {4}{0}B: {5}",
                                      Environment.NewLine,
                                      inputDate,
                                      minDate,
                                      maxDate,
                                      A,
                                      B));
    }
    else
    {
        MessageBox.Show("Invalid input");
    }
