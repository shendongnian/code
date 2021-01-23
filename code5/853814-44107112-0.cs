     private void SetReadonly(Control c)
        {
            if (c == null)
            {
                return;
            }
            foreach (Control item in c.Controls)
            {
                
                if (item is TextBox)
                {
                    ((TextBox)item).ReadOnly = true;
                }
                
                else if (item.HasControls())
                {
                    SetReadonly(item);
                }
            }
        }
