    Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@fld_Active", "Yes" },
        { "@fld_IDNo", 1 }
    };
    
    SqlClass sql = new SqlClass();
    sql.ExecuteNonQuery("UPDATE tbl_Table SET fld_Active = @fld_Active WHERE fld_IDNo = @fld_IDNo", 
        parameters);
