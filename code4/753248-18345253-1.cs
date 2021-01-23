    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    
    public partial class RP : System.Web.UI.Page
    {
        private const int ContentPerTab = 20;
    
        private DataTable SomeDatatable;
    
        protected void Page_Load(object sender, System.EventArgs e)
        {   
    
            if (!Page.IsPostBack)
            {
                //1) Load SomeDatatable from Database somehow
                // Just for testing : replace with query to DB
                SomeDatatable = new DataTable("x");
                SomeDatatable.Columns.Add(new DataColumn("ContentIndex", Type.GetType("System.Int32")));
                SomeDatatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
                for (int x = 1; x <= 50; x++)
                {
                    SomeDatatable.Rows.Add(new object[] {
    				x,
    				"Content " + x
    			});
                }
                ///////////////////
    
                //2) Create a dummy data source for the tab repeater using a list of anonymous types
                List<object> TabList = new List<object>();
    
    
                for (int I = 0; I < Math.Ceiling((decimal)SomeDatatable.Rows.Count / (decimal)ContentPerTab); I++)
                {
                    TabList.Add(new { TabIndex = I });
                }
    
                TabRepeater.ItemDataBound += TabRepeater_ItemDataBound;
                TabRepeater.DataSource = TabList;
                TabRepeater.DataBind();
    
                TablLinkRepeater.DataSource = TabList;
                TablLinkRepeater.DataBind();
            }
        }
    
    
    
        protected void TabRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int TabIndex = -1;
                int.TryParse(DataBinder.Eval(e.Item.DataItem, "TabIndex").ToString(), out TabIndex);
    
                //Copy Content Rows from SomeDatable that belong to this tab
                DataTable Dt = SomeDatatable.Clone();
                for (Int32 i = TabIndex * ContentPerTab; i <= (TabIndex + 1) * ContentPerTab - 1; i++)
                {
                    if (i >= SomeDatatable.Rows.Count) break;
    
                    Dt.ImportRow(SomeDatatable.Rows[i]);
                }
    
                // Find the content repeater in this item and use the new datatable as source
                Repeater ContentRepeater = (Repeater)e.Item.FindControl("ContentRepeater");
    
                ContentRepeater.ItemDataBound += ContentRepeater_ItemDataBound;
    
                ContentRepeater.DataSource = Dt;
                ContentRepeater.DataBind();
            }
        }
    
        //This handler might be needed for content repeater, included just for testing 
        protected void ContentRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Read coulmn from Datarow
                int ContentIndex = -1;
                int.TryParse(DataBinder.Eval(e.Item.DataItem, "ContentIndex").ToString(), out ContentIndex);
    
                // Find some label
                Label Name = (Label)e.Item.FindControl("Name");
                Name.Text = "Content #" + ContentIndex;
            }
        }
    }
