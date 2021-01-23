    // Returns the user's out-of-office message, or null if the user does not have out-of-office set.
    public static string GetUserOutOfOfficeMessage(string userEmailAddress)
    {
        const string outOfOfficeRequestMessageTemplate =
           @"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                            xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                            xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
                            xmlns:t=""http://schemas.microsoft.com/exchange/services/2006/types"">
                <soap:Header>
                    <t:RequestServerVersion Version=""Exchange2010""/>
                </soap:Header>
                <soap:Body>
                    <GetMailTips xmlns=""http://schemas.microsoft.com/exchange/services/2006/messages"">
                    <SendingAs>
                        <t:EmailAddress>{0}</t:EmailAddress>
                        <t:RoutingType>SMTP</t:RoutingType></SendingAs>
                        <Recipients>
                        <t:Mailbox>
                            <t:EmailAddress>{1}</t:EmailAddress>
                            <t:RoutingType>SMTP</t:RoutingType>
                        </t:Mailbox>
                        </Recipients>
                    <MailTipsRequested>OutOfOfficeMessage</MailTipsRequested>
                    </GetMailTips>
                </soap:Body>
             </soap:Envelope>";
        string exchangeServiceUrl = "https://.../Exchange.asmx";  // get the full URL from your Exchange admin
        WebRequest exchangeServiceRequest = WebRequest.Create(exchangeServiceUrl);
        HttpWebRequest exchangeSoapServiceRequest = (HttpWebRequest)exchangeServiceRequest;
        exchangeSoapServiceRequest.Method = "POST";
        exchangeSoapServiceRequest.ContentType = "text/xml; charset=utf-8";
        exchangeSoapServiceRequest.ProtocolVersion = HttpVersion.Version11;
        exchangeSoapServiceRequest.Credentials = new NetworkCredential(serviceAccountUserName, 
            serviceAccountPassword, yourDomain);  // for serviceAccountUserName try either login name or email address
        exchangeSoapServiceRequest.Timeout = 60000;
        Stream exchangeSoapServiceRequestStream = exchangeSoapServiceRequest.GetRequestStream();
        using (StreamWriter exchangeServiceWriter = new StreamWriter(exchangeSoapServiceRequestStream, Encoding.ASCII))
        {
            string outOfOfficeMessageRequest = string.Format(
                outOfOfficeRequestMessageTemplate, serviceAccountUserName, userEmailAddress);
            try
            {
                exchangeServiceWriter.Write(outOfOfficeMessageRequest);
            }
            catch (Exception ex)
            {
                // log something
            }
            finally
            {
                exchangeServiceWriter.Close();
            }
        }
        string outOfOfficeResponse = null;
        string userOutOfOfficeMessage = null;
        try
        {
            HttpWebResponse exchangeServiceResponse = (HttpWebResponse)exchangeSoapServiceRequest.GetResponse();
            using (StreamReader exchangeServiceResponseStream = new StreamReader(exchangeServiceResponse.GetResponseStream()))
            {
                outOfOfficeResponse = exchangeServiceResponseStream.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            // log something
        }
        if (outOfOfficeResponse != null)
        {
            const int messageElementStartTagLength = 11;
            int messageStartIndex = outOfOfficeResponse.IndexOf("<t:Message>");
            if (messageStartIndex >= 0)
            {
                int messageEndIndex = outOfOfficeResponse.IndexOf("</t:Message>");
                if (messageEndIndex >= 0)
                {
                    int outOfOfficeMessageLength = messageEndIndex - messageStartIndex;
                    // Adjust for length of the <t:message> tag itself so that we don't include the tag in the output.
                    messageStartIndex += messageElementStartTagLength;
                    outOfOfficeMessageLength -= messageElementStartTagLength;
                    userOutOfOfficeMessage = outOfOfficeResponse.Substring(messageStartIndex, outOfOfficeMessageLength);
                }
            }
        }
        return userOutOfOfficeMessage;
    }
