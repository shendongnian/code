    #region Save the Records to the DataBase
    
            private void btnSave_Click(object sender, EventArgs e)
            {
    
                try
                {
                    //Reconnect to Database
                    System.Data.SqlClient.SqlCommandBuilder cb;
                    cb = new System.Data.SqlClient.SqlCommandBuilder(dataAdapter);
    
                    //Create a new row
                    DataRow dr = ds.Tables["tblImpi"].NewRow();
    
                    //save the record to first column
                    dr[0] = txtSerial.Text;
    
                    //Check data entry if its not empty
                    if (txtcallSign.Text != "")
                    {
    
                        dr[1] = txtcallSign.Text;
    
                    }
    
                    //Check if ip textbox is empty
                    if (txtIp.Text != "")
                    {
                        dr[2] = txtIp.Text;
                    }
    
                    //Check if port is empty
                    if (txtPort.Text != "")
                    {
                        dr[3] = txtPort.Text;
                    }
    
                    //check if gsm txtbox is empty
                    if (txtGsm.Text != "")
                    {
    
    
                        dr[4] = txtGsm.Text;
                    }
    
                    //check iriduim txtbox
                    if (txtiriduim.Text != "")
                    {
                        dr[5] = txtiriduim.Text;
                    }
    
                  
                    //check software version
                    if (txtSoftVersion.Text != "")
                    {
                        dr[6] = txtSoftVersion.Text;
                    }
    
    
                    //Check if serial number,gsm sim,iriduim value is not zero
                    if ((txtSerial.Text.Length != 0) || (txtGsm.Text.Length != 0) || (txtiriduim.Text.Length != 0))
                    {
                        //Create a search Method to search before you save the serial number
                        bool search = SearchRecBeforeSave(txtSerial.Text, txtGsm.Text, txtiriduim.Text);
                        //bool search = SearchSerialNumberBeforeSave(txtSerial.Text);
                        if (search == false)
                        {
    
                            DialogResult dr2 = MessageBox.Show("Do you want to  save", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr2 == DialogResult.Yes)
                            {
                                ds.Tables["tblImpi"].Rows.Add(dr);
                                System.Data.SqlClient.SqlCommandBuilder cb1;
                                cb1 = new System.Data.SqlClient.SqlCommandBuilder(dataAdapter);
                                cb1.DataAdapter.Update(ds.Tables["tblImpi"]);
    
    
    
                                MessageBox.Show("Data Saved","Save");
                            }
    
    
    
                            // DialogResult dr2 = MessageBox.Show("Are you sure  you want to save this serial number", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            else if (txtGsm.Text == "")
                            {
                                txtGsm.Text = "";
                                txtGsm.ForeColor = Color.Red;
                                tootip.SetToolTip(txtGsm, txtGsm.Text);
    
                            }
    
                            else if (txtiriduim.Text == "")
                            {
                                txtiriduim.Text = " ";
                                txtiriduim.ForeColor = Color.Red;
                                tootip.SetToolTip(txtiriduim, txtiriduim.Text);
    
                            }
    
                            else if (txtcallSign.Text.Length == 0)
                            {
    
                                txtcallSign.Text = "";
                                txtcallSign.ForeColor = Color.Red;
                                tootip.SetToolTip(txtcallSign, txtcallSign.Text);
                            }
    
    
                        }
    
                        else
                        {
                            MessageBox.Show("The information that you have enterd already exist\nPlease Enter a Correct Entries ", "Data Entry");
                            txtSerial.Text = "Please Enter Impi Serial Number";
                            txtSerial.ForeColor = Color.Red;
                            tootip.SetToolTip(txtSerial, txtSerial.Text);
    
                            txtcallSign.Text = "Please Enter Call Sign";
                            txtcallSign.ForeColor = Color.Red;
                            tootip.SetToolTip(txtcallSign, txtcallSign.Text);
    
    
                            txtIp.Text = "Please Enter Ip Adress";
                            txtIp.ForeColor = Color.Red;
                            tootip.SetToolTip(txtIp, txtIp.Text);
    
                            txtPort.Text = "Please Enter Port Number";
                            txtPort.ForeColor = Color.Red;
                            tootip.SetToolTip(txtPort, txtPort.Text);
    
                            txtGsm.Text = "Please Enter the GSM Sim Number";
                            txtGsm.ForeColor = Color.Red;
                            tootip.SetToolTip(txtGsm, txtGsm.Text);
    
                            txtiriduim.Text = "Please Enter the IMEI Number ";
                            txtiriduim.ForeColor = Color.Red;
    
                            tootip.SetToolTip(txtiriduim, txtiriduim.Text);
                        }
                    }
    
                    else if ((txtSerial.Text == "") && (txtIp.Text == "") && (txtPort.Text == "") && (txtiriduim.Text == "") && txtGsm.Text == "")
                    {
                        MessageBox.Show("Please Enter a data", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }
    
                }
    
    
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Incorrect Data Entry", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }
    
                con.Close();
    
            }
