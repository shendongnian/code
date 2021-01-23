    SqlConnection sqlCon2 = new SqlConnection("REMOVED");
    SqlCommand sqlCmd2 = new SqlCommand();
    sqlCmd2.CommandText = "SELECT QtyOnHand FROM Products.Products WHERE PartNumber like '" + textBox1.Text + "'";
    sqlCmd2.Connection = sqlCon2;
    sqlCon2.Open();
     using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"excelfile.csv"))
     {
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
           file.WriteLine(reader[0]);
        }
    
        reader.Close();
     }
    
    sqlCon2.Close();
