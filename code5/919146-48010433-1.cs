    dynamic message = new JObject();
    message.ErrorMessage = "";
    message.ErrorDetails = new JObject();
    message.ErrorDetails.ErrorId = 111;
    message.ErrorDetails.Description = new JObject();
    message.ErrorDetails.Description.Short = 0;
    Console.WriteLine(message.ToString());
    // Ouputs:
    // { 
    //   "ErrorMessage": "",
    //   "ErrorDetails": {
    //     "ErrorID": 111,
    //     "Description": {
    //       "Short": 0
    // .....  
