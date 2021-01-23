    protected void datalist2_OnItemCreated(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Footer)
        {
            DropDownList drpdKategoria = e.Item.FindControl("drpdKategoria") as DropDownList;
            SqlConnection con = new SqlConnection(connection)
            string Qry = "select * from kategoria";
            SqlDataAdapter da = new SqlDataAdapter(Qry, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            drpdKategoria.DataSource = ds;
            drpdKategoria.DataValueField = "id";
            drpdKategoria.DataTextField = "emertimi";
            drpdKategoria.DataBind();
            con.Close();
            con.Dispose();
            ds.Dispose();
            da.Dispose(); 
        }
    }
