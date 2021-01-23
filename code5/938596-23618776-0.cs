    protected void drp1_SelectedIndexChanged(object sender, EventArgs e)
        {
    //Check TextBox first
    if(TextBoxID.Text==string.Empty)
    {
            int ProductID = Convert.ToInt16(drp1.SelectedValue);
            DataTable Signing = new DataTable();
            SqlConnection conn = new SqlConnection(connection);
            SqlDataAdapter da = new SqlDataAdapter("SELECT SigningID, SigningDetail FROM dbo.Signing WHERE ProductID = "+ ProductID, conn);
            conn.Open();
            da.Fill(Signing);
            conn.Close();
            drp2.DataSource = Signing;
            drp2.DataValueField = "SigningID";
            drp2.DataTextField = "SigningDetail";
            drp2.DataBind();
            drp2.Items.Insert(0, new ListItem("---Select Signing Detail---", "0"));
        }
    }
