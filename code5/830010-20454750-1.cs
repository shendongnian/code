    MySqlConnection conn = new MySqlConnection(connstr);
    string UpdStmt = "update UOMS_V " 
                   + " set UOM_Code = ?parmUOM_Code, "
                   + "     Descp = ?parmDescp, "
                   + "     Remark = ?parmRemark "
                   + " where UOM_Code = ?parmWhereUOM_Code ";
    
    MySqlCommand cmd = new MySqlCommand(UpdStmt, conn);
    cmd.Parameters.AddWithValue( "?parmUOM_Code", TbUOMCode );
    cmd.Parameters.AddWithValue( "?parmDescp", TbDescp );
    cmd.Parameters.AddWithValue( "?parmRemark", TbRemark );
    cmd.Parameters.AddWithValue( "?parmWhereUOMCode", DsUOMCode );
        
    // Then apply your try/catch
    try
    {
       // open the connection
       // execute it... etc
    }
    catch
    {
    }
