        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                Session["List"] = null;
                ViewState["i"] = ViewState["j"] = 1;
                ViewState["state"] = "";
            }
        }
        public static DataTable dt;
        public static int i = 1;
        protected void txtName_Click(object sender, EventArgs e)
        {
            Session["List"] = dt;
            dt = new DataTable();
            DataRow dr = null;
            
            dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            if (Session["List"] == null)
            {
                if (Convert.ToInt16(ViewState["i"]) == Convert.ToInt16(ViewState["j"]))
                {
                    dr = dt.NewRow();
                    dr["RowNumber"] = i;
                    dr["Column1"] = Convert.ToString(ViewState["state"]) + txtName.Text;
                    ViewState["state"] = Convert.ToString(ViewState["state"]) + txtName.Text;
                    dt.Rows.Add(dr);
                }
                grdData.DataSource = dt;
                grdData.DataBind();
            }
                  if (Session["List"] != null)
                {
          if  ( Convert .ToInt16 ( ViewState["i"] )!=  Convert .ToInt16 ( ViewState["j"]))
            {
               
               
                    dt = (DataTable)Session["List"];
                    dr = dt.NewRow();
                    dr["Column1"] =  txtName.Text;
                    dr["RowNumber"] = i;
                    
                    dt.Rows.Add(dr);
                    //lst = (List<string>)Session["List"];
                    //lst.Insert(i,txtAdd.Text);
                    //i++;
                    grdData.DataSource = dt;
                    grdData.DataBind();
                }
          else if (Convert.ToInt16(ViewState["i"]) == Convert.ToInt16(ViewState["j"]))
          {
              dt = (DataTable)Session["List"];
             ViewState["state"] = grdData.Rows[((grdData.Rows.Count) - 1)].Cells[1].Text;
             string i =Convert.ToString( ViewState["state"]);
             int j = dt.Rows.Count;
              dt.Rows[(dt.Rows.Count)-1]["Column1"] =Convert.ToString(ViewState["state"])+ txtName.Text;
              grdData.DataSource = dt;
              grdData.DataBind();
          }
         
                ViewState["i"] = ViewState["j"];
            }
           txtName.Text = "";
           
        }
        protected void btnClr_Click(object sender, EventArgs e)
        {
            ViewState["j"] = i++;
            ViewState["state"] = "";
           // txtName.Text = grdData.Rows[(grdData.Rows.Count - 1)].Cells[1].Text;
         
        }
        protected void btnnew_Click(object sender, EventArgs e)
        {
           
            dt.Rows[(grdData.Rows.Count - 1)]["Column1"] = txtName.Text;
            grdData.DataSource = dt;
            grdData.DataBind();
        }
    }
