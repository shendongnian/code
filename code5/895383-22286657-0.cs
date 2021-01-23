    public void rozne()
            {
    
                string constr = Properties.Settings.Default.DodgeBulletsDBConnectionString;
                //Form1 menuglowne = new Form1();
    
                using (SqlCeConnection con = new SqlCeConnection(constr))
                {
                    SqlCeCommand com = new SqlCeCommand("SELECT Big_blind, Small_blind FROM Site WHERE Level=1", con);
                    con.Open();
                    SqlCeDataReader reader = com.ExecuteReader();
    
                    bool hasRow = reader.Read();
                    if (hasRow)
                    {
                        int bb = reader.GetInt32(reader.GetOrdinal("Big_blind"));
                        int sb = reader.GetInt32(reader.GetOrdinal("Small_blind"));
                        this.lbl_sb_text = Convert.ToString(sb);
                        this.lbl_bb_text = Convert.ToString(bb);
                    }
                    else
                    {
                        MessageBox.Show("Coś się zjebało z importem DS.Site.");
                    }
                }
            }
