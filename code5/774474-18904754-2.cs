    void btnSubmit_Click(object sender, EventArgs e)
    {
      //--------------------------------------------------------------------------------------------------
      //Extract encrypted values from the Request.Form object
      //braintree.js has encrypted these values before placing them in
      //the Request object.
      //--------------------------------------------------------------------------------------------------
      string number = Request.Form["number"].ToString();
      string cvv = Request.Form["cvv"].ToString();
      string month = Request.Form["month"].ToString();
      string year = Request.Form["year"].ToString();
        
      //--------------------------------------------------------------------------------------------------
      //Gateway
      //This is the Braintree Gateway that we will use to post the transaction
      //to.  This is included here in the example but should be extracted out
      //into some static class somewhere.  Possibly in another layer.
      //--------------------------------------------------------------------------------------------------
      BraintreeGateway Gateway = new BraintreeGateway
      {
        Environment = Braintree.Environment.SANDBOX,
        PublicKey = "YOURPUBLICKEYHERE",
        PrivateKey = "YOURPRIVATEKEYHERE",
        MerchantId = "YOURMERCHANTIDHERE"
      };
        
      //--------------------------------------------------------------------------------------------------
      //Transaction Request
      //This is the actual transaction request that we are posting to the 
      //Braintree gateway.  The values for number, cvv, month and year have 
      //been encrypted above using the braintree.js.  If you were to put a 
      //watch on the actual server controls their ".Text" property is blank
      //at this point in the process.
      //--------------------------------------------------------------------------------------------------
      TransactionRequest transactionRequest = new TransactionRequest
      {
        Amount = 100.00M,
        CreditCard = new TransactionCreditCardRequest
        {
          Number = number,
          CVV = cvv,
          ExpirationMonth = month,
          ExpirationYear = year,
        }
      };
        			
      //--------------------------------------------------------------------------------------------------
      //Transaction Result
      //Here we are going to post our information, including the encrypted
      //values to Braintree.  
      //--------------------------------------------------------------------------------------------------
      Result<Transaction> result = Gateway.Transaction.Sale(transactionRequest);
    }
