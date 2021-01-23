    private void OpenFormWithAuthentication(Form destination)
    {
        SecurityCheck secForm = new SecurityCheck();
        secForm.ShowDialog();
        if(secForm.DialogResult == DialogResult.Ok)
        {
            destination.Show();
        }
    }
