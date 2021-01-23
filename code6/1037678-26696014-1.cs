        private void btnDialogLogin_Click(object sender, EventArgs e)
        {
            // Form validation here...
            var result = SystemManager.AdminLogin(NameButton.Text, PassButton.Text);
            DialogResult = DialogResult.No;
            if (result)
            {
                DialogResult = DialogResult.Yes;
            }
            this.Close();
        }
