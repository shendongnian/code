    private void helpButton_Click(object sender, EventArgs e)
    {
       label3.Text = GetHelpText();
       label3.AutoSize = true;
    }
    // Always good practice to name a method that returns something Get...
    // Also good practice to give it a descriptive name.
    private string GetHelpText()
    {
        return test >= 10    // The ?: operator just means if the first part is true...
               ? test.ToString().SubString(0, 1)   // use this, otherwise...
               : "Hint not possible, number is less than ten" // use this.
    }
