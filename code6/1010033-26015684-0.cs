    try
             {
                 cn.Open();
                 string query = "select employee_id,Employee_Name,Image_of_Employee from Employee_Details where employee_id='" + dataGridView1.SelectedCells[0].Value.ToString() + "'";
                 SqlCommand cmd = new SqlCommand(query, cn);
                 SqlDataReader sdr;
                 sdr = cmd.ExecuteReader();
                 if (sdr.Read())
                 {
                     string aa = (string)sdr["employee_id"];
                     string bb = (string)sdr["employee_name"];
                     txtEmployeeID.Text = aa.ToString();
                     txtnameofemployee.Text = bb.ToString();
                     byte[] img=(byte[])sdr["Image_of_employee"];
                     MemoryStream ms=new MemoryStream(img);
                     ms.Seek(0,SeekOrigin.Begin);
                     pictureBox1.Image=Image.FromStream(ms);   cn.Close();
                 }
                
             }
             catch (Exception e1)
             {
                 MessageBox.Show(e1.Message);
             }
             
