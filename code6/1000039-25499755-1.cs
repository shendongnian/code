    private void txtdays_KeyDown(object sender, KeyEventArgs e)
        {
    
            if(e.KeyCode==Keys.Enter)
            {
                var control = this.Controls
                        .Cast<Control>()
                        .Where(r => r.TabIndex == txtdays.TabIndex + 1).First();
                control.Focus();
            }
        }
