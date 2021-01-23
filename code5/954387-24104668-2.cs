     private Control FindControl(Control.ControlCollection controlCollection, string name)
        {
            foreach (Control control in controlCollection)
            {
                if (control.Name.ToLower() == name.ToLower())
                {
                    return control;
                }
                if (control.Controls.Count > 0)
                {
                    Control result = FindControl(control.Controls, name);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
