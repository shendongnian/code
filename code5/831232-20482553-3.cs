    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    namespace GridViewTest
    {
        public partial class WebForm3 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindData();
                }
    
            }
            private void BindData()
            {
                var lstItems = new List<ListItem>()
                {
                    new ListItem {Text ="Items 1", Value ="1"},
                    new ListItem {Text ="Items 2", Value ="2"},
                    new ListItem {Text ="Items 3", Value ="3"},
                    new ListItem {Text ="Items 4", Value ="4"}
    
                };
                GridView1.DataSource = lstItems;
                GridView1.DataBind();
            }
          
    
            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["onclick"] = string.Format("RowSelect({0});", e.Row.RowIndex);
      
            }
    
            protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                BindData();
                GridView1.Rows[index].Attributes.Add("style", "background-color:yellow");
                GridView1.Rows[index].Attributes.Add("class", "mycustomclass");
            }
        }
           
    }
