    SqlDataReader rdr = comm.ExecuteReader();
    if (rdr.HasRows)
    {
        reader.Read();
        Dept.DepartmentID = Convert.ToInt32(rdr["ID"].ToString());
        Dept.DepartmentName = rdr["Name"].ToString();
        Dept.Description = rdr["Description"].ToString();
        reader.Close();
    }
    else
    { //No data
    }
    
