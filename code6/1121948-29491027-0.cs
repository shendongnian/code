        private void CmbBx_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbBx.Text != string.Empty 
                && !this.cmbBx.Text.Contains(".25")
                && !this.cmbBx.Text.Contains(".50")
                && !this.cmbBx.Text.Contains(".75"))
            {
                this.cmbBx.Items.Clear();
                this.cmbBx.Items.Add(this.cmbBx.Text + ".25");
                this.cmbBx.Items.Add(this.cmbBx.Text + ".50");
                this.cmbBx.Items.Add(this.cmbBx.Text + ".75");
            }
            if (this.cmbBx.Text == string.Empty)
            {
                this.cmbBx.Items.Clear();
            }
            SendKeys.Send("{F4}");
        }
