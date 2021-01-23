    TimeSpan ts = TimeSpan.Parse(timeTextBox.Text);
        
    double rate, cost;
        
    double.TryParse(rateTextBox.Text, out rate); 
    double.TryParse(prescriptionTextBox.Text, out cost);
        
    subAmountLabel.Text = ts.TotalHours.ToString("f2");
    double total = ts.TotalHours * rate + cost;
    totalAmountLabel.Text = total.ToString("f2");
