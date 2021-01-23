    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    using System.Diagnostics;
    using System.Text;
    
    namespace addlabels
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
    
            int pressNumberOfTimes;
            Label lbl_homeCarouselAdd = new Label();
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
    
            protected void add_click(object sender, EventArgs e)
            {
                // Add the panel
                pressNumberOfTimes++;
    
               
    
                // Set the label's Text and ID properties.
                lbl_homeCarouselAdd.ID = "lbl_homeCarouselAdd" + pressNumberOfTimes;
    
                StringBuilder strDiv = new StringBuilder();
                strDiv.Append(string.Format(@"<p class='style'>Hello world</p>"));
    
                lbl_homeCarouselAdd.Text += strDiv.ToString();
    
    
                Panel1.Controls.Add(lbl_homeCarouselAdd);
            }
        }
    }
