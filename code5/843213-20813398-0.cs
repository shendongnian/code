     public class img : IHttpHandler,System.Web.SessionState.IReadOnlySessionState
        {
            Connection connect = new Connection();
            public void ProcessRequest(HttpContext context)
            {
                if (context.Session["emp"].ToString() != null)
                {
                    try
                    {
                        string text;
                        text =retrive your data from here by using  context.Session["emp"]
                        DataTable dt1 = connect.exexc(text, connect.connectfunction());
                        if (dt1.Rows.Count > 0)
                        {
                            string img = dt1.Rows[0].ItemArray[0].ToString();
                            byte[] imageBytes = Convert.FromBase64String(img);
                            context.Response.ContentType = "image/JPEG";
                            context.Response.BinaryWrite(imageBytes);
                        }
                     }
                    catch
                    {
    
                    }
                }
             }
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
 
