      protected void Page_Load(object sender, EventArgs e)
        {
            SetReadonly(this);
        }
        private void SetReadonly(Control c)
        {
            if (c == null)
            {
                return; 
            }
            foreach (Control item in c.Controls)
            {
                if (item.HasChildren)
                {
                    SetReadonly(c);
                }
                else if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                }
    
            }
        }
     
