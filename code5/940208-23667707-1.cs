    private void OnKeyPress(...)
    {
       double parsedValue = 0;
       if (double.TryParse(MyTextBox.Text, out parsedValue)
       {
           //Valid number entered, value in parsedValue
       }
       else
       {
           //Invalid number entered
       }
    }
