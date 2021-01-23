     SqlConnection koneksi = null;
            koneksi = new SqlConnection(conn);
            koneksi.Open();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"D:\DBXML.xml");
            XmlElement root = xmldoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/students/student");
            DataTable dt = new DataTable();
            dt.Columns.Add("Nama", typeof(string));
            dt.Columns.Add("Alamat", typeof(string));
            foreach (XmlNode item in nodes)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item["name"].InnerText;
                dr[1] = item["address"].InnerText;
                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;
               
              
 
            }
            //senddtata();
            string dtout = dt.Rows[2][1].ToString();
        
            SqlCommand cmd = new SqlCommand("InsertSiswa",koneksi);
            cmd.CommandType = CommandType.StoredProcedure;
            {
                //DataTable dt = new DataTable();
                cmd.Parameters.Add(new SqlParameter("@mytable", dt));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sukses");
            }
        }
