    foreach (UpdatePanel updatePanel in page.Form.Controls.OfType<UpdatePanel>().ToList())
    {
        foreach (Control control in updatePanel.Controls.OfType<Control>().ToList())
        {
            foreach (Panel panel in control.Controls.OfType<Panel>().ToList())
            {
                foreach (Label label in panel.Controls.OfType<Label>().ToList())
                {
                    TextBox txtColumnName = panel.FindControl(label.AssociatedControlID) as TextBox;
    
                    if (txtColumnName != null)
                    {
                        RequiredFieldValidator rqrdColumn = new RequiredFieldValidator();
                        rqrdColumn.Display = ValidatorDisplay.None;
                        rqrdColumn.ID = "rqrd1";
                        rqrdColumn.ControlToValidate = txtColumnName.ID;
                        rqrdColumn.ErrorMessage = "Can not be blank";
                        rqrdColumn.ValidationGroup = "vg";
                        ValidatorCalloutExtender vceColumn = new ValidatorCalloutExtender();
                        vceColumn.ID = "vce";
                        vceColumn.TargetControlID = rqrdColumn.ID;
                        panel.Controls.Add(rqrdColumn);
                        panel.Controls.Add(vceColumn);
                        updatePanel.ContentTemplateContainer.Controls.Add(p);
                        updatePanel.Update();
                    }
                }
            }
        }
    }
