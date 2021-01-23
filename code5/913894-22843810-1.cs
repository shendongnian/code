    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void gettickvalue(object sender, EventArgs e)
        {   
            Random RandomNumber = new Random();
            int n = RandomNumber.Next(1, 9);
            imgBanner.ImageUrl = String.Concat("Timer/banner_", n.ToString(), ".jpg");  
        }
    } //we added this curly brace
