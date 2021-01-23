    int RecPos = this.BindingContext[estDataSet, "uoms_v"].Position;
    string DsUOMCode = estDataSet.Tables["UOMS_V"].Rows[RecPos]["UOM_Code"].ToString();
    string TbUOMCode = this.txtUOMCode.Text;
    
    string DsDescp = estDataSet.Tables["UOMS_V"].Rows[RecPos]["Descp"].ToString();
    string TbDescp = this.txtDescp.Text;
    
    string DsRemark = estDataSet.Tables["UOMS_V"].Rows[RecPos]["Remark"].ToString();
    string TbRemark = this.txtRemark.Text;
    
    if (  DsUOMCode == TbUOMCode
       && DsDescp == TbDescp
       && DsRemark == TbRemark ) 
    {
       MessageBox( "No changes made" );
       return;
    }
    
    MySqlConnection conn = new MySqlConnection(connstr);
    string UpdStmt = "update UOMS_V set "
    MySqlCommand cmd = new MySqlCommand("", conn);
    string AddComma = "";
    
    if (DsUOMCode != TbUOMCode)
    {
       // just continue to add the build string
       UpdStmt += " UOM_Code = ?parmUOM_Code ";
       cmd.Parameters.AddWithValue( "?parmUOM_Code", TbUOMCode );
       // in case any additional components to be updated you can
       // add a "," between each update field component.
       AddComma = ",";  
    }
    
    if (DsDescp != TbDescp)
    {
       // in case the TbUOMCode had something, add comma BEFORE this field instance
       UpdStmt += AddComma + " Descp = ?parmDescp ";
       cmd.Parameters.AddWithValue( "?parmDescp", TbDescp );
       // in case any additional components to be updated you can
       // add a "," between each update field component.
       AddComma = ",";  
    }
    
    if (DsRemark != TbRemark)
    {
       // in case the TbUOMCode had something, add comma BEFORE this field instance
       UpdStmt += AddComma + " Remark = ?parmRemark ";
       cmd.Parameters.AddWithValue( "?parmRemark", TbRemark );
       // in case you want to add any MORE change columns after this one
       AddComma = ",";  
    }
    
    // Now, tack on the WHERE clause...
    UpdStmt += " WHERE UOM_Code = ?parmWhereUOMCode "
    cmd.Parameters.AddWithValue( "?parmWhereUOMCode", DsUOMCode );
    
    // Now, since we changed the "UpdStmt" value from its original command creation, 
    // just update the commandText property.... leave parameters alone
    cmd.CommandText = UpdStmt;
    
    // Then apply your try/catch
    try
    {
       // open the connection
       // execute it... etc
    }
    catch
    {
    }
