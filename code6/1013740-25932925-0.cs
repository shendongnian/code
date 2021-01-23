    int selectedBuilding = int.Parse(listBox1.GetItemText(listBox1.SelectedValue));
    using (SqlConnection conn = new SqlConnection("ConnectionStrin")) {
                using (SqlCommand cmd = new SqlCommand("SELECT ID, Name FROM Printers WHERE BuildingID = " + selectedBuilding + "", conn)) {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();
                listBox2.DataSource = dt;
                listBox2.ValueMember = "ID";
                listBox2.DisplayMember = "Name";
            }
        }
