      private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmUpdate f2 = new frmUpdate();
                f2.lblClientID.Text = kryptonDataGridView1.SelectedRows[0].Cells["ClientID"].Value.ToString();
                f2.lblClearinAgentID.Text = kryptonDataGridView1.SelectedRows[0].Cells["Clearing_Agent_ID"].Value.ToString();
                f2.textboxClientCode.Text = kryptonDataGridView1.SelectedRows[0].Cells["Client Code"].Value.ToString();
                f2.txtboxClientName.Text = kryptonDataGridView1.SelectedRows[0].Cells["Client Name"].Value.ToString();
                f2.txtboxPostalAddress.Text = kryptonDataGridView1.SelectedRows[0].Cells["Postal Address"].Value.ToString();
                f2.txtboxTelephone.Text = kryptonDataGridView1.SelectedRows[0].Cells["Telephone"].Value.ToString();
                f2.txtboxFax.Text = kryptonDataGridView1.SelectedRows[0].Cells["Fax"].Value.ToString();
                f2.txtboxEmailAddress1.Text = kryptonDataGridView1.SelectedRows[0].Cells["E-mail Address 1"].Value.ToString();
                f2.txtboxEmailAddress2.Text = kryptonDataGridView1.SelectedRows[0].Cells["E-mail Address 2"].Value.ToString();
                f2.txtboxEmailAddress3.Text = kryptonDataGridView1.SelectedRows[0].Cells["E-mail Address 3"].Value.ToString();
                f2.txtboxWebsite.Text = kryptonDataGridView1.SelectedRows[0].Cells["Website"].Value.ToString();
                f2.txtboxChargeRate.Text = kryptonDataGridView1.SelectedRows[0].Cells["Charge Rate"].Value.ToString();
                f2.txtboxTotalDepo.Text = kryptonDataGridView1.SelectedRows[0].Cells["Total Deposit"].Value.ToString();
                f2.txtboxAccountBal.Text = kryptonDataGridView1.SelectedRows[0].Cells["Account Balance"].Value.ToString();
            
                f2.ShowDialog();
                LoadClient();
            }
