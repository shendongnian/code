    using(new OperationContextScope(client.InnerChannel)) {
    // We will use a custom class called UserInfo to be passed in as a MessageHeader
    UserInfo userInfo = new UserInfo();
    userInfo.FirstName = "John";
    userInfo.LastName = "Doe";
    userInfo.Age = 30;
 
    // Add a SOAP Header to an outgoing request
    MessageHeader aMessageHeader = MessageHeader.CreateHeader("UserInfo", "http://tempuri.org", userInfo);
    OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);
