    private void calulateButton_Click(object sender, EventArgs e)
    {
        string[] item = timeTextBox.Text.Split(':');
        int totalHours, mins, prescription;
        double rate;
        int.TryParse(item[0], out totalHours);
        int.TryParse(item[1], out mins);
        double.TryParse(rateTextBox.Text, out rate); 
        int.TryParse(prescriptionTextBox.Text, out prescription);
        subAmountLabel.Text = totalHours.ToString("f2");
        double total = (totalHours + mins/60) * rate + prescription;
        totalAmountLabel.Text = total.ToString("C");
    }
