    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           UserContext conObj = new UserContext();
           HttpContext CurrContext = HttpContext.Current;
           if (!IsPostBack)
           {
               // Code
           }
           else
           {
               string userContext = hdnContextObj.Value;
               conObj = JsonConvert.DeserializeObject<UserContext>(userContext);
               CurrContext.Items.Add("Context", conObj);
               Server.Execute("Payment.aspx?vpc_ChannelId=2", true);
               Response.End(); // or return;
           }
        }
        catch (Exception xObj)
        {
           Response.Write("Exception : " + xObj.Message);
        }
    }
