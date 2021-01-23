    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {    
               DisableControlsInPage(this.Page,false);    
            } 
        }
    
        protected void DisableControlsInPage(Control parent, bool isEnable) {
            foreach(Control c in parent.Controls) {
                if (c is TextBox) {
                    ((TextBox)(c)).Enabled = isEnable;
                }
                if (c is RadioButton) {
                    ((RadioButton)(c)).Enabled = isEnable;
                }    
                DisableControlsInPage(c, isEnable);
            }
        }
