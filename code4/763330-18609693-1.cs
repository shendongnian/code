     DataSet ds = new DataSet();
    
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myString"].ConnectionString);
    
    String qry="SELECT topic_ID,topic_title FROM FPL2012_TOPIC WHERE topic_isEnabled = 1; SELECT itemExplanationType_ID, itemExplanationType_type FROM FPL2012_ITEM_EXPLANATION_TYPE ";
    
    SqlDataAdapter da = new SqlDataAdapter(qry, connection);
    
    da.Fill(ds)
    
    topicDropDownList.DataValueField = "topic_ID";
    topicDropDownList.DataTextField = "topic_title";
    topicDropDownList.DataSource = ds.Tables[0];
    topicDropDownList.DataBind();
    
    explanationTypeDropDownList.DataValueField = "itemExplanationType_ID";
    explanationTypeDropDownList.DataTextField = "itemExplanationType_type";
    explanationTypeDropDownList.DataSource = ds.Tables[1];
    explanationTypeDropDownList.DataBind();
    
    connection.Close();
