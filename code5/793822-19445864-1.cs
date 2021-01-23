        private void BtnOk_Click(object sender, EventArgs e)
        {
            _Repository.Create(mydata);
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
