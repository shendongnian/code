        private void bindingNavigator1SaveItem_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "Special") && (textBox2.Text == "Record"))
            {
                MessageBox.Show("Cannot change this record.",
                    "Save operation aborted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            try
            {
                this.Validate();
                this.bindingSource1.EndEdit();
                this.tableAdapterManager1.UpdateAll(this.DataSet1);
                this.tableAdapter1.Fill(DataSet1.Customers);
                this.bindingSource1.Position = this.DataSet1.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
