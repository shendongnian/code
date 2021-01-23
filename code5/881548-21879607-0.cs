        private void EmployeeAttendence_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
              try
              {
                  table = dbOperation.select("employs.emp_id, employs.emp_name, employs.emp_fname, designation.name from employs inner join designation on designation.id = employs.designation");
                  listView1.Items.Clear();
                  foreach (DataRow row in table.Rows)
                  {
                    listView1.Items.Add(row[0].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(row[1].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(row[2].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(row[3].ToString());
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add("P");
                  }
                  table = dbOperation.select("* from designation");
                  comboBox1.Items.Clear();
                  comboBox1.DataSource = table;
                  comboBox1.DisplayMember = "name";
                  comboBox1.ValueMember = "id";
              }
              catch (Exception ex)
              {
                 MessageBox.Show(ex.ToString());
              }
            }
        }
