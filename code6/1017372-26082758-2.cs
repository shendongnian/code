        private void button1_Click(object sender, EventArgs e)
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Input Required Fields!",
                "Note",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                    }
                    
                    else
                    {
        
                        //Passing the value from textbox
                        Tic_Tac_Toe frm2 = new Tic_Tac_Toe(textBox1.Text);
                        View view = new View(textBox1.Text);
                  
                        string str = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Majel\Tic Tac Toe\Database\Database.mdb";
        
                        OleDbConnection con = new OleDbConnection(str);
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM data WHERE Users = '" + textBox1.Text, con);
                        OleDbDataAdapter ta=new OleDbDataAdapter(cmd);
                        DataSet ds=new DataSet();
                         try
                        {
                        ta.Fill(ds);
                        if(ds.Tables[0].Rows.Count==0)
                        {
                            MessageBox.Show("User Dos not Exists");
                            Application.Exit();
                        }
                        string hash=ds.Tables[0].Rows[0]["password"];
                        string salt=ds.Tables[0].Rows[0]["salt"];
                             if(IsPasswordCorrect(textBox2.Text,salt,hash))
                             {
                                 MessageBox.Show("Success");
                            this.Hide();
                            frm2.Show();
    
    
                        }
    
    
                        else
                        {
                            MessageBox.Show("Invalid User Name or Password",
            "Note",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
    
                        }
    
                    }
    
                    catch (Exception ex)
                    {
    
                        MessageBox.Show(ex.Message);
    
                    }
    
                    finally
                    {
    
                        con.Close();
    
                    }
                }
            }
