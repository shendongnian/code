    private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            C_CUSTOMER cst = new C_CUSTOMER();
            C_ACCOUNT acc = new C_ACCOUNT();
            cst.FIRST_NAME = txtFname.Text;
            cst.MIDDLE_NAME = txtMname.Text;
            cst.LAST_NAME = txtLname.Text;
            cst.LOCATION = txtlocation.Text;
            cst.DATE_OF_BIRTH = Convert.ToDateTime(dateTimePicker1.Text);
            acc.ACCOUNT_BALANCE = Convert.ToInt32(txtInitAmoun.Text);
            acc.ACCOUNT_NUMBER = Convert.ToInt32(txtAccNumber.Text);
            cst.TELEPHONE = Convert.ToInt32(txtTelephone.Text);
            
            cst.DATE_CREATE = DateTime.Now;
            int newID = cstDao.insertCustomer(cst.FIRST_NAME, cst.MIDDLE_NAME, cst.LAST_NAME, cst.LOCATION, cst.DATE_OF_BIRTH, cst.TELEPHONE, cst.MODIFY_BY, cst.DATE_MODIFY, cst.DATE_CREATE);
            acc.CUSTOMER_ID = newID;
            acc.DATE_CREATED = DateTime.Now;
            acc.CREATED_BY = 1;
            int newAccID  = cstDao.insertAccount(acc);
            if(newID != 0 && newAccID != 0) { 
            MessageBox.Show("Insert Succefull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
            }
            else
            {
                MessageBox.Show("Error during the insertion", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ReloadGrid();
        }
