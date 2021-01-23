    protected void myWiz_NextButtonClick(object sender, WizardNavigationEventArgs e) {
        switch (e.CurrentStepIndex) {
            case 0:
                // on step 0, moving to step 1
            case 1:
               // on step 1, moving to step 2
            ...
        }        
      }
      protected void myWiz_PreviousButtonClick(object sender, WizardNavigationEventArgs e) {
        switch (e.CurrentStepIndex) {
            case 1:
                // on step 1, moving to step 0
            case 2:
               // on step 2, moving to step 1
            ...
        }   
      }
      protected void myWiz_FinishButtonClick(object sender, WizardNavigationEventArgs e) {
          // Regardless of step, validate and perform wizard wrap up
      }
