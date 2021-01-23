    public partial class Default : System.Web.UI.Page 
    { 
    protected void Page_Load(object sender, EventArgs e) 
    { 
        // Add relative web pages and user controls in assembly and this application. 
        DataTable tab = this.InitializeDataTable(); 
        if (tab != null && tab.Rows.Count != 0) 
        { 
            for (int i = 0; i < tab.Rows.Count; i++) 
            { 
                Control control = Page.LoadControl(tab.Rows[i]["UserControlUrl"].ToString()); 
                UserControl usercontrol = control as UserControl; 
                Page.Controls.Add(usercontrol); 
                HyperLink link = new HyperLink(); 
                link.NavigateUrl = tab.Rows[i]["WebPageUrl"].ToString(); 
                link.Text = tab.Rows[i]["WebPageText"].ToString(); 
                Page.Controls.Add(link); 
            } 
        } 
    } 
 
 
    /// <summary> 
    /// Initialize a DataTable variable for storing URL and text properties.  
    /// </summary> 
    /// <returns></returns> 
    protected DataTable InitializeDataTable() 
    { 
        DataTable tab = new DataTable(); 
        DataColumn userControlUrl = new DataColumn("UserControlUrl",Type.GetType("System.String")); 
        tab.Columns.Add(userControlUrl); 
        DataColumn webPageUrl = new DataColumn("WebPageUrl", Type.GetType("System.String")); 
        tab.Columns.Add(webPageUrl); 
        DataColumn webPageText = new DataColumn("WebPageText", Type.GetType("System.String")); 
        tab.Columns.Add(webPageText); 
        DataRow dr = tab.NewRow(); 
        dr["UserControlUrl"] = "~/Assembly/CSASPNETAssembly.dll/CSASPNETAssembly.WebUserControl.ascx"; 
        dr["WebPageUrl"] = "~/Assembly/CSASPNETAssembly.dll/CSASPNETAssembly.WebPage.aspx"; 
        dr["WebPageText"] = "Assembly/WebPage"; 
        DataRow drWebSite = tab.NewRow(); 
        drWebSite["UserControlUrl"] = "~/WebSite/WebUserControl.ascx"; 
        drWebSite["WebPageUrl"] = "~/WebSite/WebPage.aspx"; 
        drWebSite["WebPageText"] = "WebSite/WebPage"; 
        tab.Rows.Add(dr); 
        tab.Rows.Add(drWebSite); 
        return tab; 
     } 
    }
