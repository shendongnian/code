    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int messageNumber = 0;
            DataTable dtMessages = (DataTable)Session["Messages"];
            if (int.TryParse(Request.QueryString["MessageNumber"].ToString(), out messageNumber) && dtMessages != null)
            {
                var m = (from DataRow dr in dtMessages.Rows
                            where (string)dr["MessageNumber"] == messageNumber.ToString()
                            select dr).FirstOrDefault();
                if (m != null)
                {
                    string sOut = m["From"].ToString() + "<br />" +
                                    m["Subject"].ToString() + "<br />" +
                                    m["DateSent"].ToString();
                    Response.Write(sOut);
                }
    
            }
        }
    }   
