            foreach (WizardStep step in Wizard1.WizardSteps)
            {
                foreach (Control c1 in step.Controls)
                {
                    if (c1 is Label)
                    {
                        Label1.Text += ((Label)c1).Text + "<br/><br/>";
                    }
                    else
                    {
                        foreach (Control c2 in c1.Controls)
                        {
                            if (c2 is RadioButtonList)
                            {
                                RadioButtonList rbl = (RadioButtonList)c2;
                                foreach (ListItem li in rbl.Items)
                                {
                                    Label1.Text += li.Text.ToString() + "<br/><br/>";
                                }
                            }
                        }
                    }
                }
