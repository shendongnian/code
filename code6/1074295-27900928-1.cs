    using System;
    
    using System.Collections.Generic;
    
    using System.Linq;
    
    using System.Web;
    
    using System.Web.UI;
    
    using System.Web.UI.WebControls;
    
    using System.Data;
    
    public partial class _Default : System.Web.UI.Page
    
    {
    
        protected void Page_Load(object sender, EventArgs e)
    
        {
    
            if (!IsPostBack)
    
            {
    
                BindData();
    
            }
    
        }
    
        protected void BindData()
    
        {
    
            DataSet ds = new DataSet();
    
            ds.ReadXml(Server.MapPath("EmployeeDetails.xml"));
    
            if (ds != null && ds.HasChanges())
    
            {
    
                gvEmployee.DataSource = ds;
    
                gvEmployee.DataBind();
    
            }
    
        }       
    
    }
    - See more at: http://www.dotnetfox.com/articles/show-gridview-row-details-in-tooltip-on-mouseover-using-jquery-in-Asp-Net-1
