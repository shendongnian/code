    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ToSession();
            FromSession();
        }
    }
    private void ToSession() 
    { 
        string[,] strTo2D = { {"A"}, {"B"} };
        Session["str2DArray"] = strTo2D; 
    }
    private void FromSession() 
    {
        string[,] strFrom2D = (string[,])Session["str2DArray"];
        Response.Write(strFrom2D[0, 0].ToString()); 
    }
