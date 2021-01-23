        private void students_CredentialsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if(!this.CheckTextBox()) return; //Stop executing code if there's invalid input
            try
            { 
                //this.Validate();
                this.students_CredentialsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.rCMDataSet);
                MessageBox.Show("Data saved successfully");
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
