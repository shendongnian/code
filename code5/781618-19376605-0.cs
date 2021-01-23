    SqlConnection con =null;
    DataSet ds=null;
    try
    {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MGLCOMConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT VALUE,VDESC FROM CSOPTFD WHERE OPTFIELD='WONO'AND VALUE LIKE '%" + customerddl.SelectedValue + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            
    }
    catch(SQLException ex)
    {
    
    }
    finally
    {
         if(con!=null)
             con.Close();
    }
    GridView1.DataSource = ds;
    GridView1.DataBind();
