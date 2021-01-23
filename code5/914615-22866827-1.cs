    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace Try1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            protected void LinkButton1_Click(object sender, EventArgs e)
            {
                string passedArgument = Request.Params.Get("__EVENTARGUMENT");
                string[] paramsArray = passedArgument.Split(',');
                Label1.Text = string.Format("Returned from server. params: {0},{1}", paramsArray[0], paramsArray[1]);
            }
        }
    }
