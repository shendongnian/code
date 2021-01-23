    <asp:DropDownList ID="ddlYearObj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlObj_SelectedIndexChanged" ></asp:DropDownList>
    <asp:DropDownList ID="ddlMakeObj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMakeObj_SelectedIndexChanged" Visible="false"></asp:DropDownList>
    <asp:DropDownList ID="ddlModelObj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModelObj_SelectedIndexChanged" Visible="false"></asp:DropDownList>
    <asp:DropDownList ID="ddlSubmodelObj" runat="server" Visible="false"></asp:DropDownList>
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = (string)Session["name"];
    
        if (!IsPostBack)
        {
            String strConnString = ConfigurationManager
                .ConnectionStrings["connectionString"].ConnectionString;
            String strQuery = "select distinct Year from dbo.Vehiclemain WHERE ISENABLED = 'YES'";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlYearObj.DataSource = cmd.ExecuteReader();
                ddlYearObj.DataTextField = "Year";
                ddlYearObj.DataValueField = "Year";
                ddlYearObj.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            //Visible!? -- All invisible until something is chosen
            ddlMakeObj.Visible = false;
            ddlModelObj.Visible = false;
            ddlSubmodelObj.Visible = false;
        }
        protected void ddlYearObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strConnString = ConfigurationManager
                .ConnectionStrings["connectionString"].ConnectionString;
            String strQuery = "select distinct Make from dbo.Vehiclemain WHERE ISENABLED = 'YES' AND YEAR = "+ ddlYearObj.Value;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlMakeObj.DataSource = cmd.ExecuteReader();
                ddlMakeObj.DataTextField = "Make";
                ddlMakeObj.DataValueField = "Make";
                ddlMakeObj.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            //Visible!
            ddlMakeObj.Visible = true;
            ddlModelObj.Visible = false;
            ddlSubmodelObj.Visible = false;
        }
        protected void ddlMakeObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strConnString = ConfigurationManager
                .ConnectionStrings["connectionString"].ConnectionString;
            String strQuery = "select distinct modelfrom dbo.Vehiclemain WHERE ISENABLED = 'YES' AND YEAR = "+ ddlYearObj.Value;
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlModelObj.DataSource = cmd.ExecuteReader();
                ddlModelObj.DataTextField = "Model";
                ddlModelObj.DataValueField = "Model";
                ddlModelObj.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            //Visible!
            ddlMakeObj.Visible = true;
            ddlModelObj.Visible = true;
            ddlSubmodelObj.Visible = false;
        }
        protected void ddlModelObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strConnString = ConfigurationManager
                .ConnectionStrings["connectionString"].ConnectionString;
            String strQuery = "select distinct Submodelfrom dbo.Vehiclemain WHERE ISENABLED = 'YES' AND YEAR = "+ ddlYearObj.Value + " AND Model = '" + ddlModelObj.Value + "'";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlSubmodelObj.DataSource = cmd.ExecuteReader();
                ddlSubmodelObj.DataTextField = "Submodel";
                ddlSubmodelObj.DataValueField = "ID";
                ddlSubmodelObj.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            //Visible!
            ddlMakeObj.Visible = true;
            ddlModelObj.Visible = false;
            ddlSubmodelObj.Visible = true;
        }
