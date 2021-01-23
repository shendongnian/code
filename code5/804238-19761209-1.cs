    private void equals_button_Click(object sender, RoutedEventArgs e)
    {
        MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
        sc.Language = "VBScript";
        //Using try catch statement just in case a user enters an invalid expression. 
        //This becomes more useful when the application gets more advanced. 
        try
        {
            object result = sc.Eval(resultBoxText);
            //Output the result somehow. E.g.: resultBox.Text = result.ToString();
        }
        catch
        {
            MessageBox.Show("Invalid expression!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
