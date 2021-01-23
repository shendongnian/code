    SqlConnection  connection= new SqlConnection(your Connection string);
    string query = "SELECT CNIC, City, MobileNo, Address, Salary, DailyWage, Status   
           FROM  Employees WHERE EmployId =@EmpID AND Emplname = @Emplname ";
    SqlCommand  command1 = new SqlCommand(query, connection); 
    connection.Open();
    command1.Parameters.AddWithValue("@EmpID",txtEmployId.Text);
    command1.Parameters.AddWithValue("@Emplname",txtEmplyName.Text);
    SqlDataReader reader1 = command1.ExecuteReader();
        while(reader1.Read())
       {
        this.txtCNIC.Text = (reader1["CNIC"].ToString());
        this.txtEmplyCity.Text = (reader1["City"].ToString());
        this.txtEmplyAddress.Text = (reader1["Address"].ToString());
        this.txtSalary.Text = (reader1["Salary"].ToString());
        this.txtDailyWage.Text = (reader1["DailyWage"].ToString());
            reader1.Close();
        }
