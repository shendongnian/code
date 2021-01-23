    catech(Exception ex)
    {
        string errorMessage = string.Empty;
        while (ex.InnerException != null)
        {
            errorMessage += ex.Message + Environment.NewLine;
            ex = ex.InnerException;
        }
        errorMessage += ex.Message + Environment.NewLine;
        MessageBox.Show(errorMessage);
    }
