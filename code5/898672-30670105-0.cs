    protected void NextButton_Click(object sender, WizardNavigationEventArgs e)
    {
        cmdCancel.Visible = true;
        VerifyPassword();
        try
        {
            if (lblPasskeyInformation.Text[0] == 'I' || lblPasskeyInformation.Text[0] == 'P')
            {
                e.Cancel = true;
                return;
            }
        }
        catch (Exception ex)
        {
            lblPasskeyInformation.Text = "You are not verified yet. Please enter the passkey.";
        }
    }
