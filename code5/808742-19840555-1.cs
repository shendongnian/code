    SqlCommand cmd = newSqlCommand("SELECT EmpName from Employee where EmpID =" +id.Text,con);
    con.open(); //Open connection
    SqlReader Read = cmd.ExecuteReader();
    if (Read.Read())
    {
     Position =Read[0].tostring();
    }
    read.close();
    con.close();//Close connection after reader finishes reading
    con.Dispose();
