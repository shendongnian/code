    var userInfo = GetUserInfo(username, password);
    
    // check if user information matches what's in the XML file. return an error if it doesnt.
    if (userInfo == null)
       Console.WriteLine("incorrect username/password");
    
    // you haven't clarified in your question what you're doing with it. But the value of 'question' is accessible like this:
    Console.WriteLine(userInfo.question);
