        this.btnSubmit.Click += new System.EventHandler(this.Submit_Click);
        this.btnCancel.Click += new System.EventHandler(this.Cancel_Click);
        TextBox txtLast = new TextBox();
        private void textBox2_Leave(object sender, EventArgs e)
        {            
            txtLast = (TextBox)sender;
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {           
            txtLast = (TextBox)sender;
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtLast.Text);
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            txtLast.Focus();
        }
