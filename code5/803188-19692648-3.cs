            public string GetText()
            {
                    return textBox1.Text;
            }
            public void btnClose_Click(object sender, EventArgs e)
            {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
            }
            public void btnCancel_Click(object sender, EventArgs e)
            {
                    this.Close();
            }
