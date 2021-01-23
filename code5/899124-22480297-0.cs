        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
        public void ClearControls()
            {
            txtName.Text=""; // use your id to clear the textbox
            txtItem.Text="";
            txtType.Text = "";
            txtBrand.Text = "";
            txtlicense.Text = "";
            txtDep.Text = "";
            txtDate.Text = "";
            txtRemark.Text = "";
            txtAr.Text = "";
            txtWereda.Text = "";
            txtKebele.Text = "";
            txtHouse.Text = "";
            txtPobox.Text = "";
            txtTel.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source= C:\Users\user\Desktop\crt_db.accdb";
            try
            {
                conn.Open();
                // for the firs table
                String Name = txtName.Text.ToString();
                String AR = txtAr.Text.ToString();
                String Wereda = txtWereda.Text.ToString();
                String Kebele = txtKebele.Text.ToString();
                String House_No = txtHouse.Text.ToString();
                String P_O_BOX = txtPobox.Text.ToString();
                String Tel = txtTel.Text.ToString();
                String Fax = txtFax.Text.ToString();
                String Email = txtEmail.Text.ToString();
                String Item = txtItem.Text.ToString();
                String Dep = txtDep.Text.ToString();
                String Remark = txtRemark.Text.ToString();
               //for the second table
                String Type = txtType.Text.ToString();
                String Brand = txtBrand.Text.ToString();
                String License_No = txtlicense.Text.ToString();
                String Date_issued = txtDate.Text.ToString();
                String my_querry = "INSERT INTO crtPro(Name,AR,Wereda,Kebele,House_No,P_O_BOX,Tel,Fax,Email,Item,Dep,Remark)VALUES('" + Name + "','" + AR + "','" + Wereda + "','" + Kebele + "','" + House_No + "','" + P_O_BOX + "','" + Tel + "','" + Fax + "','" + Email + "','" + Item + "','" + Dep + "','" + Remark + "')";
                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                String my_querry1 = "SELECT LAST(PID) FROM crtPro";
                OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);
                string var = cmd1.ExecuteScalar().ToString();
                txtStatus.Text = var;
                String PID = txtStatus.Text.ToString();
                String my_querry2 = "INSERT INTO crtItemLicense(PID,Type,Brand,License_No,Date_issued)VALUES('" +PID + "','" + Type + "','" + Brand + "','" + License_No + "','" + Date_issued + "')";
                OleDbCommand cmd2 = new OleDbCommand(my_querry2, conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Message added succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
