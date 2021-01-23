    public class ImageHandler : IHttpHandler
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dboBlog"].ConnectionString);
            public void ProcessRequest(HttpContext context)
            {
                try
                {
                    string messageid = context.Request.QueryString["mid"];
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT Image from BlogMessages WHERE Image IS NOT NULL AND MessageID=" + messageid, conn);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    context.Response.BinaryWrite((Byte[])dr[0]);
                    conn.Close();
                    context.Response.End();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
