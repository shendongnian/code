    using System;
    
    namespace AspDotNetStorefront
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            private static int _clickedCount = 0;
    
            protected void lnk1_Click(object sender, EventArgs e)
            {
                ++_clickedCount;
                var suffix = _clickedCount <= 1 ? "time" : "times";
                lnk_1.Text = string.Format("Clicked {0} {1}", _clickedCount, suffix);
            }
        }
    }
