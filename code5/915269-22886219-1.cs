    private delegate void writeToTextBoxDelegate(List a, List b);
    private async void DataReceived(object sender, EventArgs e)
    {
        while (serialPort1.BytesToRead > 0 && serialPort1.IsOpen)
        {
            await Task.Factory.StartNew(() =>
            {
                // Do whatever work you want to do here.
                // When you're all done, call the following line.
                textBox.Invoke(
                    new writeToTextBoxDelegate(writeToTextBox),
                    new object[] { a, b }
                );
            });
        }
    }
