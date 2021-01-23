    public void Fill(int sysuserid, string dbconnection)
            {
    //            DateTime start = new DateTime(DateTime.Now.Ticks);
                SqlConnection _conn = new SqlConnection( dbconnection);
                SqlCommand _comm = new SqlCommand("Get_RxWorks_Menues",_conn);
                _comm.CommandType = CommandType.StoredProcedure;
                SqlParameter _param = new SqlParameter("@sysuserid",sysuserid);
                _comm.Parameters.Add(_param);
                SqlDataAdapter _da = new SqlDataAdapter(_comm);
                _da.Fill(_table);
     //           DateTime end = new DateTime(DateTime.Now.Ticks);
     //           MessageBox.Show(end.Subtract(start).TotalMilliseconds.ToString());
            }
