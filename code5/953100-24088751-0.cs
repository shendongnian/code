    protected void Page_Load(object sender, EventArgs e)
    {
        errorDirect.Visible = false;
        try
        {
            //lots of code to process the payment
        }
        catch (Exception ex)
        {
            Application.Current.Dispatcher.Invoke( ()=> errorDirect.Visible = true);
            Response.Redirect("ErrorPage.aspx");
        }
    }
