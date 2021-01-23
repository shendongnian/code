    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGridView();
        }
    }
    private void BindGridView()
    {
        using (var dtStudent = this.GetStudentData())
        {
            this.grd1.DataSource = dtStudent;
            this.grd1.DataBind();
        }
    }
    private DataTable GetStudentData()
    {
        var dtStudent = new DataTable();
        dtStudent.Columns.Add("StudentID");
        dtStudent.Columns.Add("StudentName");
        dtStudent.Columns.Add("FatherName");
        for (int i = 0; i < 20; i++)
        {
            var sIndex = i.ToString("00");
            dtStudent.Rows.Add("Student-" + sIndex, "Name-" + sIndex, "Father-" + sIndex);
        }
        return dtStudent;
    }
    
    protected void grd1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.grd1.PageIndex = e.NewPageIndex;
        this.BindGridView();
    }
    protected void ExporttoExcel()
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=Report.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        // ************************
        this.grd1.AllowPaging = false; // <- disable paging then render
        this.BindGridView();
        // ************************
        this.grd1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected override void Render(HtmlTextWriter writer)
    {
        if (this._Export)
            this.ExporttoExcel();
        else
            base.Render(writer);
    }
    private bool _Export = false;
    protected void btnExport_Click(object sender, EventArgs e)
    {
        this._Export = true;
    }
