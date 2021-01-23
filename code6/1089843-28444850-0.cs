    private IEnumerable<StripeCustomer> GetCustomers()
    {
        var customerservice = new StripeCustomerService(System.Web.Configuration.WebConfigurationManager.AppSettings["StripeApiKey"]);
        return customerservice.List();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            StripeCustomer list = GetCustomers();
            //show this list somewhere
        }
        catch (StripeException ex)
        {
            //lblerror.Text = (ex.Message);
        }
    }
