    int iChk = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                 this.rptCols.DataSource = LoadColsDataSet(); //load data from database
                 this.rptCols.DataBind();
            }
        }
        catch (Exception ex)
        {
            //display error in some label
        }
    }
    protected void rptCols_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView drv = (DataRowView)e.Item.DataItem;
                Label lblCol = e.Item.FindControl("lblCol") as Label;
                CheckBox chkCol = e.Item.FindControl("chkSelect") as CheckBox;
                Label lblHidc = e.Item.FindControl("lblHidCol") as Label;
                lblCol.Text = drv.Row["DBCol1"].ToString();
                chkCol.Checked = Convert.ToBoolean(drv.Row["DBCol2"].ToString());
                lblHidc.Text = drv.Row["DBCol3"].ToString();
            }
        }
        catch (Exception ex)
        {
            this.lblException.Text = ex.Message.ToString();
        }
    }
    protected void wibHideShow_Click(object sender, EventArgs e)
    {
        List<UserSettings> lstColsGrid = new List<UserSettings>();
        iChk = 0;
        string sUser = Session["BEMSID"].ToString();
        ArrayList ar = GetChecked();
        foreach (RepeaterItem item in rptCols.Items)
        {
            UserSettings us = new UserSettings();
            Label lblColName = item.FindControl("lblCol") as Label;
            Label hidAppName = item.FindControl("lblHidCol") as Label;
                  
             us.BemsId = sUser;
             us.ApplicationName = hidAppName.Text;
             us.ColumnName = lblColName.Text;
             us.ColumnValue = ar[iChk].ToString();
             us.LastUpdateDate = System.DateTime.Now;
             iChk++;
             lstColsGrid.Add(us);
         }
         rptCols.DataSource = LoadColsDataSet(lstColsGrid); //Update and load data
         rptCols.DataBind();
         iChk = 1;
     }
        
        private ArrayList GetChecked()
        {
            ArrayList ar = new ArrayList();
            int chkNo = 0;
            string strChkNo = string.Empty;
            string[] strChk = hidChk.Value.Split('&');
            
            //initialize array with all false
            for (int i = 0; i < rptCols.Items.Count; i++)
            {
                ar.Add("false");
            }
            for (int i = 0; i < strChk.Length; i++)
            {
                strChkNo = strChk[i].Replace("%3A", ":");
                if (strChkNo != "")
                {
                    chkNo = Convert.ToInt16(Regex.Match(strChkNo, @"\d+").Value); //Extract int from string
                    ar[--chkNo] = "true";
                }
            }
            
            return ar;
        }
