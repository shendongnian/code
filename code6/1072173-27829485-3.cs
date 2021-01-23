    private void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
        // Your initial method call could potentially look like this.
        Methods.StopUpperAndSpace(this.SomeTextBox);
        // Alternatively you could do something like this.
        this.SomeOtherTextBox.Text = Methods.ToLowerAndTrim(this.SomeOtherTextBox.Text);
    }
