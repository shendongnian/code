    ConnectionStringSettings consettings = ConfigurationManager.ConnectionStrings["attendancemanagement"];
           string connectionString = consettings.ConnectionString;
           SqlConnection cn = new SqlConnection(connectionString);
           cn.Open();
           
           try
           {
               string dtp = dateTimePicker1.Value.ToString("dd/MM/yyyy");
               string query = "select employee_id,employee_name,image_of_employee,image_path from Employee_Details where employee_id not in (select employee_id from dailyattendance where date = '" + dtp + "')";//Here added a new query which is working
               
               SqlCommand cmd = new SqlCommand(query, cn);
               SqlDataReader dtr;
               dtr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dtr);
                
               foreach (DataRow row in dt.Rows)
               {
                   var name = (string)row["employee_name"];
                   row["employee_name"] = name.Trim();
               }
                comboBox1.ValueMember = "employee_id";
                comboBox1.DisplayMember = "employee_name";
                listBox1.ValueMember = "employee_id";
                listBox1.DisplayMember = "employee_name";            
                comboBox1.DataSource = dt;
                listBox1.DataSource = dt;
                comboBox1.SelectedItem = null;
                listBox1.SelectedItem = null;
               cn.Close();
           }
           catch (System.Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
              
