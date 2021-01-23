    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		DropDownList ddl_Answer;
    		//get current index selected
    		int current_eng_sk = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Value);
    		ddl_Answer = e.Row.FindControl("ddl_Answer") as DropDownList;
    		using (SqlConnection con2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString)) 
    		{
    			con2.Open();
    			using (SqlCommand cmd1 = new SqlCommand("select distinct DD_ANSWER from table1 D, table2 Q where Q.ANS_OPT = D.ID and  ENG_SK= '" + current_eng_sk + "' and Q.ANS_OPT is not null ", con2)) 
    			{
    				ddl_Answer.DataSource = cmd1.ExecuteReader();
    				ddl_Answer.DataTextField = "DD_ANSWER";
    				ddl_Answer.DataValueField = "DD_ANSWER";
    				ddl_Answer.DataBind();
    			}
    		}
    	}
    }
