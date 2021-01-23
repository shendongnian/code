    private void ValidateName(object sender, CancelEventArgs e)
    {
        // early initialization of errorMsg to fill it if necessary
        string errorMsg = null;
        // check your textbox
        if (String.IsNullOrEmpty(txtNAME.Text))
        {
            errorMsg = "No name provided!";
        }
        // this is the interesting part
        _ErrorProvider.SetError(lblTELEPHONE, errorMsg);
        e.Cancel = errorMsg != null;
    }
