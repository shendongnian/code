    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            switch (Request.Form["form.origin"]) {
                case "first":
                    // first for has asp.net spesifics. Because its the main runat server form
                    foreach (var key in Request.Form.AllKeys) {
                        Response.Write(string.Format("{0}: {1}", key, Request.Form[key]) + "<br/>");
                    }                    break;
                case "second":
                    //seccond form contains only values from the post.
                    foreach (var key in Request.Form.AllKeys) {
                        Response.Write(string.Format("{0}: {1}", key, Request.Form[key]) + "<br/>");
                    }                    break;
                default:
                    break;
            }
        }
        protected void Button1_Click(object sender, EventArgs e) {
            
        }
        
    }
