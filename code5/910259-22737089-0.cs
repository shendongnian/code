    if (line != PassWord)
    {
        var result = MessageBox.Show(message, "Error", MessageBoxButtons.RetryCancel,    MessageBoxIcon.Information);
        if (result == MessageBoxResult.Cancel)
        {
            // User chose cancel, close app or whatever
        }
        else
        {
            // User pressed retry, nothing really happens
        }
    }       
    else if (line == PassWord)
    {
        Close();
    }
