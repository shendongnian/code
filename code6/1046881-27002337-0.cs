    var webServiceSoapClient = new  Q26998366_ConsumeAsmx.Dixon.WebServiceSoapClient ("WebServiceSoap");
    foreach (Dixon.User user in  webServiceSoapClient.Data()) 
    {
        Console.WriteLine(String.Format("Name: {0}\nPass: {1}\nSalt: {2}\n"
            , user.username, user.password, user.salt)); 
    }
