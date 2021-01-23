    SqlParameter param = new SqlParameter();
    param.ParameterName = "@ID";
    param.SqlDbType = SqlDbType.Int;
    param.Direction = ParameterDirection.Input;
    param.Value = txtTID.Text;
    command.Parameters.Add(param).Value = Int32.Parse(txtTID.Text);
