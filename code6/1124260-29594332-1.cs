        control.SearchProperties.Add(
        //take some identical property here, matching all possible controls (e.g. PropertyNames.Name; if that property is the same for all your Images)
        );
                UITestControlCollection controlcollection = control.FindMatchingControls();
                    foreach (UITestControl x in controlcollection)
                    {
                        if (x is WpfImage)
                        {
                            AutomationElement temp = (AutomationElement)x; //cast the WpfControl to an AutomationElement
                            string automationId =
            temp.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty) as string;
                            if(automationId.contains("_STATUS"))
                            {
                                 //go on..
                            }
                        }
                    }
