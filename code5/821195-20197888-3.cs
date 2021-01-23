            private void calulateButton_Click(object sender, EventArgs e)
        {
            string[] item = timeTextBox.Text.Split(':');
            int hours, mins;
            int.TryParse(item[0], out hours);
            int.TryParse(item[1], out mins);
            double rate, prescription;
            double totalHours = hours + mins / 60.0;
            
            double.TryParse(rateTextBox.Text, out rate);
            double.TryParse(prescriptionTextBox.Text, out prescription);
            double total = totalHours * rate + prescription;
            subAmountLabel.Text = totalHours.ToString("G");
            totalAmountLabel.Text = total.ToString("C");
        }
