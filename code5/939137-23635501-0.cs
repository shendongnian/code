        private void GetAllControls(Control container, Type type)
        {
            foreach (Control control in container.Controls)
            {
                if (control.Controls.Count > 0)
                {
                    GetAllControls(control, type);
                }
                if (control.GetType() == type) ControlList.Add(control);
            }
        }
