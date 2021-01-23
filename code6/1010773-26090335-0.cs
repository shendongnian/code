    private void btnPrint_Click(object sender, EventArgs e)
            {
                DataBase db = new DataBase();
                db.getConnection();
                db.con.Open();
    
                string Name = txtCostumerName.Text;
                string DayorNight = cboSwimming.Text;
                string Adult1 = txtAdultCount.Text;
                string Kid = txtKidsCount.Text;
                string Cottage1 = cboCottageType.Text;
                string Room = cboRoomType.Text;
                double Total1 = Convert.ToDouble(lblCottageTotal.Text);
                double Cash1 = Convert.ToDouble(txtCashRecieve.Text);
                double Change1 = Convert.ToDouble(txtChange.Text);
                OleDbCommand command = new OleDbCommand("INSERT INTO  TicketAndCottage (Costumer_Name , Swimming, Adult, Kids, Cottage, Room , Total, Cash, Change) Values(@Name , @DayorNight , @Adult1 ,@Kid , @Cottage1 , @Room, @Total1 , @Cash1 , @Change1)", db.con);
    
                if (db.con.State == ConnectionState.Open)
                {
                    command.Parameters.Add("@Costumer_Name", OleDbType.VarChar, 50).Value = Name;
                    command.Parameters.Add("@Swimming", OleDbType.VarChar, 50).Value = DayorNight;
                    command.Parameters.Add("@Adult", OleDbType.VarChar, 50).Value = Adult1;
                    command.Parameters.Add("@Kids", OleDbType.VarChar, 50).Value = Kid;
                    command.Parameters.Add("@Cottage", OleDbType.VarChar, 50).Value = Cottage1;
                    command.Parameters.Add("@Room", OleDbType.VarChar, 50).Value = Room;
                    command.Parameters.Add("@Total", OleDbType.Double, 50).Value = Total1;
                    command.Parameters.Add("@Cash", OleDbType.Double, 50).Value = Cash1;
                    command.Parameters.Add("@Change", OleDbType.Double, 50).Value = Change1;
    
                    try
                    {
                        command.ExecuteNonQuery();
                        db.con.Close();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Source);
                        // db.con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Connection Failed");
                }
    }
