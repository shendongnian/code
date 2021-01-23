    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication2
    {
        public partial class Test : System.Web.UI.Page
        {
            DataTable dt;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                Debug.WriteLine("Page_Load");
                dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Name");
    
                DataRow mark = dt.NewRow();
                mark["Name"] = "Mark";
                dt.Rows.Add(mark);
    
                DataRow bill = dt.NewRow();
                bill["Name"] = "Bill";
                dt.Rows.Add(bill);
    
                lvTest.DataSource = dt;
                lvTest.DataBind();
            }
    
            protected void lvTest_ItemDataBound(object sender, ListViewItemEventArgs e)
            {
                Debug.WriteLine("ItemDataBound");
            }
    
            protected void lvTest_DataBinding(object sender, EventArgs e)
            {
                Debug.WriteLine("DataBinding");
            }
    
            protected void lvTest_DataBound(object sender, EventArgs e)
            {
                Debug.WriteLine("DataBound");
            }
        }
    }
