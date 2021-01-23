    protected void wizard1_ActiveStepChanged ( object sender, EventArgs e ) {
        Button btnNext , btnFinish;
        switch(wizard1.ActiveStepIndex) {
            case 1:
                btnNext = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnNext");
                btnFinish = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnFinish");
                btnNext.ValidationGroup = "valAutUniq";
                btnNext.Visible = true;
                btnFinish.Visible = false;
                wizard1.MoveTo(WizardStep2);
                break;
            case 2:
                btnNext = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnNext");
                btnFinish = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnFinish");
                btnNext.ValidationGroup = "valAutUniq";
                btnNext.Visible = true;
                btnFinish.Visible = false;
                wizard1.MoveTo(WizardStep3);
                break;
            case 3:
                btnNext = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnNext");
                btnFinish = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnFinish");
                btnNext.ValidationGroup = "valFormPag";
                btnNext.Visible = true;
                btnFinish.Visible = false;
                wizard1.MoveTo(WizardStep4);
                break;
            case 4:
                btnNext = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnNext");
                btnFinish = (Button)wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("btnFinish");
                btnNext.ValidationGroup = null;
                btnNext.Visible = false;
                btnFinish.Visible = true;
                wizard1.MoveTo(WizardStep5);
                break;
        }
    }
