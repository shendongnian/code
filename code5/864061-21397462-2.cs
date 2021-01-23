    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Winthusiasm.HtmlEditor;
    
    namespace ListDrop
    {
        public partial class _Default : System.Web.UI.Page
        {
    
    
          
            protected void Page_Load(object sender, EventArgs e)
            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                    {
                        Editor editor= (Editor)item.FindControl("Editor1");
                        lblMessage.Text = editor.Text;
    
    
                    }
                }
            }
    
         
    
    
    
        }
    }
