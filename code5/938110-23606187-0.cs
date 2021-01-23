    using (SqlConnection cn = new SqlConnection(SqlHelper.ConString))
	{
	    DataSet DsXmlData = new DataSet();                                 
	    DsXmlData.ReadXml(xml_file_path);
	    DsXmlData.Tables["RSN_ALL"].PrimaryKey = new DataColumn[] { DsXmlData.Tables["RSN_ALL"].Columns["RSN"] };
	    using (SqlDataAdapter da = new SqlDataAdapter("select * from RSN_All", cn))
	    {
	        DataSet ds = new DataSet();
	        da.Fill(ds, "RSN_ALL");  
	        string updataCommand ="update RSN_All set Batch_M_id = @Batch_M_id ,Parent_RSN =@Parent_RSN, Pkg_Location =@Pkg_Location, CompanyId =@CompanyId where RSN =@RSN";
	        SqlCommand cmd = new SqlCommand(updataCommand, cn);
	        cmd.Parameters.Add("@Batch_M_id", SqlDbType.BigInt, 0, "Batch_M_id");
	        cmd.Parameters.Add("@Parent_RSN", SqlDbType.VarChar , 20, "Parent_RSN");
	        cmd.Parameters.Add("@Pkg_Location", SqlDbType.NVarChar , 100, "Pkg_Location");
	        cmd.Parameters.Add("@CompanyId", SqlDbType.Int , 0, "CompanyId");
	        cmd.Parameters.Add("@RSN", SqlDbType.VarChar , 20, "RSN");
	        da.UpdateCommand = cmd;
	        da.Update(ds, "RSN_ALL");
	    }
	}
