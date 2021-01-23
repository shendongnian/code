            DataLayer datalayer = new DataLayer();
            conOpen = datalayer.connectionOpen();
            string myString = Request.QueryString["searchText"].ToString();
            char[] separator = new char[] { ' ' };
            arrayList = myString.Split(separator);
            StringBuilder arrayQuery = new StringBuilder();
            SqlCommand myCommand = new SqlCommand();
            
            for (int i = 0; i < arrayList.Length; i++)
            {
                if (i==0)
                {
                    arrayQuery.Append("Select * from tbl_products where product_name LIKE @asd" + i);
                    myCommand.Parameters.AddWithValue("@asd" + i, "%" + arrayList[i] + "%");
                } else{
                    arrayQuery.Append(" OR LIKE @asd" + i );
                    myCommand.Parameters.AddWithValue("@asd" + i, "%" + arrayList[i] + "%");
                }
            }
           
            myCommand.CommandText = arrayQuery.ToString();
            myCommand.Connection = conOpen;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(myCommand);
            da.Fill(ds, "tbl_products");
            GridView1.DataSource = ds;
            GridView1.DataBind();
