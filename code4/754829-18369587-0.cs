    Dim GridView1 As New GridView
    
    SqlDataSource1.SelectCommand = "SELECT * FROM TableName"
    GridView1.DataSource = SqlDataSource1
    GridView1.DataBind()
    
    Response.Clear()
    Response.Buffer = True
    Response.ContentType = "application/vnd.ms-excel"
    Response.Charset = ""
    Me.EnableViewState = False
    Dim oStringWriter As New System.IO.StringWriter
    Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)
    
    GridView1.RenderControl(oHtmlTextWriter)
    
    Response.Write(oStringWriter.ToString())
    Response.End()
