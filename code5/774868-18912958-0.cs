     private void ClearInputs(ControlCollection ctrls)
            {
                foreach (Control ctrl in ctrls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = string.Empty;
    
                    ClearInputs(ctrl.Controls);
                }
            }
