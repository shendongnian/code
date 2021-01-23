    if(this.cmbError.SelectedIndex == -1 || this.cmbError.SelectedIndex == 0)
    {
      ocom.Parameters.Add(":param", OracleDbType.Varchar2).Value = DB.Null;
    }
    else
    {
     ocom.Parameters.Add(":param", OracleDbType.Varchar2).Value = 
        cmbError.text;
    }
 
