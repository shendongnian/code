    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Connect();
        }
    
        try
        {
            cm = new SqlCommand("select profile_pic from TblNewMemberRegistration where    user_name='sudhanshu@mailbox.com'", cn);
            byte[] b = (byte[])cm.ExecuteScalar();
            stream.Write(b, 0, b.Length);
            Bitmap bm = new Bitmap(stream);
            Response.ContentType = "image/gif";
            bm.Save(Response.OutputStream, ImageFormat.Gif);
        }
        catch(Exception ex) 
        {
            Response.Write(ex.Message);
        }
        finally
        {
            cn.Close();
            stream.Close();
        }
    }
    protected void Connect()
    {
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        cn.Open();
    
    
    }
