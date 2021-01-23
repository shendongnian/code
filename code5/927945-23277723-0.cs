        protected void Page_Load(object sender, EventArgs e)
        {
          If(!IsPostBack)
           {
            ddlBusinessUnit.DataSource = sqlCommands.GetBusinessUnits();
            ddlBusinessUnit.DataValueField = "BusinessUnit";
            ddlBusinessUnit.DataBind();
            ddlBusinessUnit.Items.Insert(0, new ListItem("", ""));
            ddlBlankForms.DataSource = sqlCommands.GetForms();
            ddlBlankForms.DataTextField = "FormDesc";
            ddlBlankForms.DataValueField = "FormReport";
            ddlBlankForms.DataBind();
            ddlBlankForms.Items.Insert(0, new ListItem("", ""));
          }
        }
