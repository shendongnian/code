    SqlConnection conn = new SqlConnection("Data Source=jaci;Initial Catalog=projecttest;Integrated Security=True");
                string querry = string.Format("SELECT name_of_course FROM course WHERE kathedra='" + comboBox1.Text + "' AND year='" + comboBox2.Text + "'");
                SqlCommand cmd = new SqlCommand(querry);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(querry, conn);
                adapter.Fill(dt);
                ds.Tables.Add(dt);
                
                    foreach (DataRow dr in dt.Rows)
                    {
                        comboBox3.Items.Add(dr[0].ToString());
                    }
