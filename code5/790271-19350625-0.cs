        DisplayOutPut.AppendText(NameTextBox.Text);
        DisplayOutPut.AppendText(Environment.NewLine);
        DisplayOutPut.AppendText(HoursTextBox.Text);
        DisplayOutPut.AppendText(RateTextBox.Text);
        DisplayOutPut.AppendText(Gross_pay.ToString("C")); // Hours*Rate
        DisplayOutPut.AppendText(Taxes.ToString("C"));
        DisplayOutPut..AppendText(Net_Pay.ToString("C"));
