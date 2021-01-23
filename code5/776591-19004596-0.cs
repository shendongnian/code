    protected void Page_Load(object sender, EventArgs e)
    {
    if (!Page.IsPostBack)
    {
        this.GetGridData();
    }
    }
     protected void BindGrid()
    {
    con.Open();
    SqlCommand cmd = new SqlCommand("Select * from CreateUser", con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    da.Fill(ds);
    con.Close();
    if (ds.Tables[0].Rows.Count > 0)
    {
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    else
    {
        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        GridView1.DataSource = ds;
        GridView1.DataBind();
        int columncount = GridView1.Rows[0].Cells.Count;
        GridView1.Rows[0].Cells.Clear();
        GridView1.Rows[0].Cells.Add(new TableCell());
        GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
        GridView1.Rows[0].Cells[0].Text = "No Records Found";
    } 
    }
      private void GetGridData()
      {
       con.Open();
       string query = "Select * from CreateUser";
       da = new SqlDataAdapter(query, con);
       DataSet ds = new DataSet();
       da.Fill(ds);
       GridView1.DataSource = ds;
       GridView1.DataBind();
       con.Close();
      }
    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        this.BindGrid();
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        //getting particular row linkbutton
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        //getting userid of particular row
        int UserID = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
        string FirstName = gvrow.Cells[0].Text;
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from CreateUser where UserID=" + UserID, con);
        int result = cmd.ExecuteNonQuery();
        con.Close();
        if (result == 1)
       {
           BindGrid();
           //Displaying alert message after successfully deletion of user
           ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('" + FirstName + " details deleted successfully')", true);
           this.GetGridData();
       }
    }
     
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    GridView1.PageIndex = e.NewPageIndex;
    GetGridData();
    }
     protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
    Label userid= (Label)row.FindControl("lblUserID");
    con.Open();
    SqlCommand cmd = new SqlCommand("delete FROM CreateUser where UserID='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
    cmd.ExecuteNonQuery();
    con.Close();
    BindGrid();
    }
     protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
    string query = string.Empty;
    string userid = GridView1.DataKeys[e.RowIndex].Values["UserID"].ToString();
    //Label id = GridView1.Rows[e.RowIndex].FindControl("lblUserID") as Label;
    TextBox FirstName = GridView1.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox;
    TextBox LastName = GridView1.Rows[e.RowIndex].FindControl("txtLastName") as TextBox;
    TextBox DomainID = GridView1.Rows[e.RowIndex].FindControl("txtDomainID") as TextBox;
    TextBox EmailID = GridView1.Rows[e.RowIndex].FindControl("txtEmailID") as TextBox;
    TextBox Password = GridView1.Rows[e.RowIndex].FindControl("txtPassword") as TextBox;
    TextBox ConfirmPassword = GridView1.Rows[e.RowIndex].FindControl("txtConfirmPassword") as TextBox;
    TextBox RoleType = GridView1.Rows[e.RowIndex].FindControl("txtRoleType") as TextBox;
    CheckBox IsEnable = GridView1.Rows[e.RowIndex].FindControl("chkIsEnableEdit") as CheckBox;
    //TextBox textadd = (TextBox)row.FindControl("txtadd");
    //TextBox textc = (TextBox)row.FindControl("txtc");
    GridView1.EditIndex = -1;
    con.Open();
    //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);
    SqlCommand cmd = new SqlCommand("update CreateUser set FirstName='" + FirstName.Text + "',LastName='" + LastName.Text + "',DomainID='" + DomainID.Text + "',EmailID='" + EmailID.Text + "',Password='" + Password.Text + "',ConfirmPassword='" + ConfirmPassword.Text + "',RoleType='" + RoleType.Text + "',Enable='" + IsEnable.Checked + "' where UserID='" + userid + "'", con);
    cmd.ExecuteNonQuery();
    con.Close();
    BindGrid();
    //GridView1.DataBind();
    }
     protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
    GridView1.EditIndex = -1;
    BindGrid();
    }
    }
