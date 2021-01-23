    public void Insert_Data(int StuID, string StuName, string StuSex, string StuCity)
    {
        adap = new SqlDataAdapter("select * from Student", con);
        SqlCommandBuilder cmdBuilder=new SqlCommandBuilder(adap);
        DataSet ds = new DataSet();
        adap.Fill(ds,"Student");
        DataRow dr = ds.Tables[0].NewRow();
        dr["ID"] = StuID;
        dr["Name"] = StuName;
        dr["Sex"] = StuSex;
        dr["City"] = StuCity;
        ds.Tables[0].Rows.Add(dr);
        ds.Tables[0].AcceptChanges();
        adap.Update(ds, "Student"); 
    }
