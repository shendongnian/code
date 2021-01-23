    List<SqlParameter> sp = new List<SqlParameter>();                    
    sp.Add(new SqlParameter("@CmpyCode", SqlDbType.NVarChar)).Value = CV.Global.CMPYCODE;
    sp.Add(new SqlParameter("@Code", SqlDbType.NVarChar)).Value = codeName;
    sp.Add(new SqlParameter("@DisplayCode", SqlDbType.NVarChar)).Value = codeName + "-";
    sp.Add(new SqlParameter("@TotalDigit", SqlDbType.Int)).Value = CV.Global.PARAMTOTALDIGIT;
    insertData(CV.Sps.SP_INSERT_PARAM_TABLE, sp);
