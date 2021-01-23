    //Store your ID from Sending Page
    Session["ID"]= "143"; //Example ID
    //To Recieve
    private void Page_Load(object sender, System.EventArgs e)
    {
       String ID = String.Empty;
       ID=Session["ID"].toString();
    }
