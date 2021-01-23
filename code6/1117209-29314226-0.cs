    protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                int ID = Convert.ToInt32(txtdriverId.Text);
                int name= Convert.ToInt32(txtdrivername.Text);
                string sqlstr = "insert into TB_DRIVER(driverId,drivername) values(" + ID + "," + name + ")";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                btnSave.Text = "Save";
            }
            if (btnSave.Text == "Update")
            {
                int ID = Convert.ToInt32(driverId.Text);
                int name= Convert.ToInt32(txtdrivername.Text);
                sqlstr = "update TB_DRIVER set driverId=" + ID + ", drivername=" + name + " where driverId=" + ID;
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                btnSave.Text = "Save";
            }
        }
        protected void GrdDrivers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                ViewState["ID"] = ID;
                string str = "select * from TB_DRIVER where driverId = '" + ID + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtdriverId.Text = dr[0].ToString();
                    txtdrivername.Text = dr[1].ToString();
                }
                con.Close();
                btnSave.Text = "Update";
            }
            BindGrid();
        }
        protected void GrdDrivers_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GrdDrivers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }
        public void BindGrid()
        {
            string sqlstr = "Select * from TB_DRIVER";
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            GrdDrivers.DataSource = ds;
            GrdDrivers.DataBind();
        }
