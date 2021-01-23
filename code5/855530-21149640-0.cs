        private void ProcessControl(Control cntrl)
        {
            if (cntrl == null)
            {
                return;
            }
            else if (cntrl is TextBox)
            {
                if (true) //condition to determine if the textbox is enabled
                {
                    cntrl.Enabled = true;
                }
                else
                {
                    cntrl.Enabled = false;
                }
            }
            else if (cntrl.HasChildren)
            {
                foreach (Control item in cntrl.Controls )
                {
                    ProcessControl(item);
                }
            }
        }
