     void additemForm_Closing(object sender, CancelEventArgs e)
        {
            strItem = this.textBox1.Text;
            strDesc = this.textBox2.Text;
            strRetail = this.textBox3.Text;
            //You can check anything here
            if (string.IsNullOrEmpty(strItem))
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
