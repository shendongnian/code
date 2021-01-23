    SqlDataReader rdr1 = null;
    SqlConnection con1 = null;
    SqlCommand cmd1 = null;
    try
            {
               List<string> namesCollection = new List<string>();
                // Open connection to the database
                string ConnectionString = @"Data Source=MyPC-PC\SQLEXPRESS;Initial Catalog=DryDB;Integrated Security=True";
                con1 = new SqlConnection(ConnectionString);
                con1.Open();
                cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "SELECT PName from MASTER order by PName";
                cmd1.Connection = con1;
                rdr1 = cmd1.ExecuteReader();
                namesCollection.Add("Select");
                if (rdr1.Read()==true)
                {
                    do
                    {
                        namesCollection.Add("" + rdr1[0].ToString());
                    } while (rdr1.Read()) ;
                }
                else
                {
                }
                //Replace this part...
                //foreach(string pname in namesCollection)
                //cb.Items.Add(pname);
                //With this...
                cb.DataSource = namesCollection;
                cb.SelectedIndex =0;
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
                if (rdr1 != null)
                    rdr1.Close();
                if (con1.State == ConnectionState.Open)
                    con1.Close();
            }
