    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        TextBox tbox = (TextBox)sender;
        string testPattern = @"^[+-]?[0-9]*\.?[0-9]+ *[+-]? *[0-9]*\.?[0-9]+$";
        Regex regex = new Regex(testPattern);
        bool isTextOk = regex.Match(tbox.Text).Success;
        if (!isTextOk)
        {
            MessageBox.Show("Error, please check your input.");
            e.Cancel = true;
        }
    }
