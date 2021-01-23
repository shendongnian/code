        protected void ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DropDownList NoSaleDropDown = (DropDownList)e.Item.FindControl("NoSaleDropDown");
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string sConnection2 = ConfigurationManager.ConnectionStrings["DevConn"].ConnectionString;
                SqlConnection dbConn2 = new SqlConnection(sConnection2);
                dbConn2.Open();
                string sqlString2 = "SELECT NoSaleReasonID, NoSaleReasonDesc FROM M_NoSaleReason";
                SqlCommand command2 = new SqlCommand();
                command2.CommandText = sqlString2;
                command2.Connection = dbConn2;
                SqlDataAdapter DataAdapter2 = new SqlDataAdapter();
                DataAdapter2.SelectCommand = command2;
                DataTable dt2 = new DataTable();
                DataAdapter2.Fill(dt2);
                if (NoSaleDropDown != null)
                {
                    NoSaleDropDown.DataTextField = "NoSaleReasonDesc";
                    NoSaleDropDown.DataValueField = "NoSaleReasonID";
                    NoSaleDropDown.DataSource = dt2;
                    NoSaleDropDown.DataBind();
                    NoSaleDropDown.SelectedValue = DataBinder.Eval(e.Item.DataItem, "NoSaleReasonID").ToString();
                }
            }
        }
