    public AstraFunctions vdaa;
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
              vdaa =  Session["vdaa"] != null ? 
                      (AstraFunctions)Session["vdaa"] : new AstraFunctions();
              ...//do somthing with vdaa 
              Session["vdaa"] = vdaa;
            }
    }
    protected void gvViewDetailedASTRAActivity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
               AstraFunctions vdaa = (AstraFunctions)Session["vdaa"]  
                vdaa.gv.ID.ToString();
                vdaa.gv_PageIndexChanging(sender, e); 
            }
            catch (Exception ex)
            {
                Response.Write("Error in gvViewUnprocessedReceipts_PageIndexChanging():  " + ex);
            }
