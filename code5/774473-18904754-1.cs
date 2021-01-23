    protected void Page_Load(object sender, EventArgs e)
    {
      //Adjust the properties of the form itself as this
      //form has a master page.			
      Form.ID = "braintree-payment-form";
        
      //Wire up the click event
      btnSubmit.Click += btnSubmit_Click;
    }
