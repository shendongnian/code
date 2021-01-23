    string strUsername = "<<paypal_username>>";
        string strPassword = "<<paypal_password>>";
        string strSignature = "<<paypal_signature>>";
        string strCredentials = "USER=" + strUsername + "&PWD=" + strPassword + "&SIGNATURE=" + strSignature;
        string strNVPSandboxServer = "https://api-3t.sandbox.paypal.com/nvp";
        string strAPIVersion = "2.3";
        //4456193676582624                                                                   4025609244685781
        string strNVP = strCredentials + "&METHOD=DoDirectPayment" +
            "&CREDITCARDTYPE=VISA" +
             "&ACCT=<<CARDNO>>" +
             "&EXPDATE=<<EXPDATE>>" +
             "&CVV2=<<CVV>" +
             "&AMT=<<AMOUNT>>" +
             "&FIRSTNAME=<<CUST_NAME>>" +
             "&LASTNAME=<<CUST_LASTNAME>>" +
             "&CURRENCYCODE=<<CURRENCY_CODE>>" +
             "&IPADDRESS=<<USER_IP>>" +
             "&STREET=<<ADDRESS>>" +
             "&CITY=<<CITY>>" +
             "&STATE=<<STATE>>" +
             "&COUNTRY=<<COUNTRY>>" +
             "&ZIP=<<XIPCODE>>" +
             "&COUNTRYCODE=<<COUNTRY>>" +
             "&PAYMENTACTION=SALE" +
             "&L_NAME0=item1&L_DESC0=test1description&L_AMT0=1&L_QTY0=1" +
             "&L_NAME1=item2&L_DESC1=test2description&L_AMT1=2&L_QTY1=2" +
             "&L_NAME2=item3&L_DESC2=test3description&L_AMT2=3&L_QTY2=3" +
             "&VERSION=" + strAPIVersion;
        //strNVP = Server.UrlEncode(strNVP);
        try
        {
            //Create web request and web response objects, make sure you using the correct server (sandbox/live)
            HttpWebRequest wrWebRequest = (HttpWebRequest)WebRequest.Create(strNVPSandboxServer);
            wrWebRequest.Method = "POST";
            StreamWriter requestWriter = new StreamWriter(wrWebRequest.GetRequestStream());
            requestWriter.Write(strNVP);
            requestWriter.Close();
            // Get the response.
            HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();
            StreamReader responseReader = new StreamReader(wrWebRequest.GetResponse().GetResponseStream());
            //and read the response
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();
            string result = Server.UrlDecode(responseData);
            string[] arrResult = result.Split('&');
            Hashtable htResponse = new Hashtable();
            string[] responseItemArray;
            foreach (string responseItem in arrResult)
            {
                responseItemArray = responseItem.Split('=');
                htResponse.Add(responseItemArray[0], responseItemArray[1]);
            }
            string strAck = htResponse["ACK"].ToString();
            if (strAck == "Success" || strAck == "SuccessWithWarning")
            {
                string strAmt = htResponse["AMT"].ToString();
                string strCcy = htResponse["CURRENCYCODE"].ToString();
                string strTransactionID = htResponse["TRANSACTIONID"].ToString();
                //ordersDataSource.InsertParameters["TransactionID"].DefaultValue = strTransactionID;
                string strSuccess = "Thank you, your order for: $" + strAmt + " " + strCcy + " has been processed.";
                Response.Write(strSuccess);
                //successLabel.Text = strSuccess;
            }
            else
            {
                string strErr = "Error: " + htResponse["L_LONGMESSAGE0"].ToString();
                string strErrcode = "Error code: " + htResponse["L_ERRORCODE0"].ToString();
                //errLabel.Text = strErr;
                //errcodeLabel.Text = strErrcode;
                return;
            }
        }
        catch (Exception ex)
        {
            // do something to catch the error, like write to a log file.
            Response.Write("error processing");
        }`enter code here`
