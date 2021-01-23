    cmd = new Oracle.DataAccess.Client.OracleCommand("Vbank_pkg.vb_log_entry", con);
    
    cmd.BindByName = true;
    cmd.CommandType = CommandType.StoredProcedure;
    
    cmd.Parameters.Add("p_rqserial", OracleDbType.Int32).Value = Log_Serial;
    cmd.Parameters.Add("p_orig", OracleDbType.Varchar2).Value = p_orig;
    cmd.Parameters.Add("p_type", OracleDbType.Char).Value = p_type;
    cmd.Parameters.Add("p_objname", OracleDbType.Varchar2).Value = p_objname;
    cmd.Parameters.Add("p_info", OracleDbType.Varchar2).Value = p_info;
    cmd.Parameters.Add("p_text", OracleDbType.Varchar2).Value = p_text;
    cmd.Parameters.Add("p_with_commit", OracleDbType.Char).Value = "1";
    
    cmd.ExecuteNonQuery();
