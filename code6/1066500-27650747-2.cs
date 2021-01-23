    private void buttonOpenWizard_Click(object sender, EventArgs e)
    {
        SampleWizard wizard = new SampleWizard();
        wizard.FormClosed += WizardClosed; // hook up event handler
        wizard.Show();
    }
    
    private void WizardClosed( object sender, FormClosedEventArgs e )
    {
        var wizard = (SampleWizard)sender;
        // check and use result of wizard here
    }
