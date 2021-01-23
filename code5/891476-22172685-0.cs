    namespace Practice_Web
    {
        public partial class Grid_Practice : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    //Dummy value for gridview
                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add(new DataColumn("Designation", typeof(String)));
                    DataRow dr = null;
                    for (int i = 0; i < 15; i++)
                    {
                        dr = dt1.NewRow();
                        dr[0] = "designation" + (i % 2);
                        dt1.Rows.Add(dr);
                    }
                    Session["dt"] = dt1;
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();    
                }
            
            }
            protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                Session["NewPageIndex"] = e.NewPageIndex;
                var sessionVar = Session["dropdownChanged"];
                bool dropdownChanged = false;
                if (sessionVar != null)
                    dropdownChanged = Convert.ToBoolean(Session["dropdownChanged"]);
                if (dropdownChanged)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "ConfirmUser('Are u sure');", true);
                }
                else
                {
                    ChangeGridPage();
                }
            }
            public void ChangeGridPage()
            {
                int pageIndex = Convert.ToInt32(Session["NewPageIndex"]);
                GridView1.PageIndex = pageIndex;
                GridView1.DataSource = (Session["dt"] as DataTable);
                GridView1.DataBind();
            }
            protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlDesignation = new DropDownList();
                    ddlDesignation.SelectedIndexChanged += new EventHandler(ddlDesignation_SelectedIndexChanged);
                    ddlDesignation.AutoPostBack = true;
                
                    ddlDesignation.ID = "MyID" + e.Row.RowIndex.ToString();
                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add(new DataColumn("Designation", typeof(String)));
                    DataRow dr = null;
                    dr = dt1.NewRow();
                    dr[0] = "designation0";
                    dt1.Rows.Add(dr);
                    dr = dt1.NewRow();
                    dr[0] = "designation1";
                    dt1.Rows.Add(dr);
                    ddlDesignation.DataSource = dt1;
                    ddlDesignation.DataTextField = "Designation";
                    ddlDesignation.DataValueField = "Designation";
                    ddlDesignation.DataBind();
                    ddlDesignation.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDesignation.SelectedValue = (Session["dt"] as DataTable).Rows[e.Row.RowIndex][0].ToString();
                
                    e.Row.Cells[0].Controls.Add(ddlDesignation);
                }
            }
            void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
            {
                Session["dropdownChanged"] = true;
                //other code here
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                ChangeGridPage();
            }
        }
    }
