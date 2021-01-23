        private void ProcessControls(Control containerControl)
        {
            foreach (Control control in containerControl.Controls)
            {
                if (control is CheckBox)
                {
                    ChangeCheckBoxProperties((CheckBox)control);
                }
                else
                {
                    ProcessControls(control);
                }
            }
        }
        private void ChangeCheckBoxProperties(CheckBox cb)
        {
            // ...
        }
