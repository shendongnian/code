    protected void Page_Load(object sender, EventArgs e)
    {
        if (null != Session["ErrorMessage"])
        {
            ErrorMessage.Visible = true;
            ErrorMessage.Text = Session["ErrorMessage"].ToString();
        }
    }
    
    protected void button_CreatUser(object sender, EventArgs e)
    {
        try
        {
            Session["ErrorMessage"] = "Registered successfully, ";
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
