     using(sConn = new SqlConnection(sStr))
     using(daEmp2 = new SqlDataAdapter("SELECT employee.*,department.Department " + 
                                "FROM tblEmployee employee inner join tblDepartment department " + 
                                "on employee.DeptID=department.DeptID " + 
                                "where Lname LIKE @last OR Fname LIKE @first", sConn))
     {
          daEmp2.SelectCommand.Parameters.AddWithValue("@last", "%" + LastNameTextBox.Text + "%");
          daEmp2.SelectCommand.Parameters.AddWithValue("@first", "%" + txtName.Text  + "%");
          dsEmp2 = new DataSet();
          daEmp2.Fill(dsEmp2, "tblEmployee");
     }
