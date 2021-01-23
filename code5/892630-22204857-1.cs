        foreach (WizardStep step in Wizard1.WizardSteps)
        {
            foreach (Control c1 in step.Controls)
            {
                if (c1 is Label)
                {
                    Label1.Text += ((Label)c1).Text + "<br/><br/>";
                }
                if(c1 is RadioButtonList)
                {
                  foreach (ListItem li in ((RadioButtonList)c1).Items)
                  { 
                    Label1.Text += li.Text + "<br/><br/>";
                  }
                }
            }
        }
                
