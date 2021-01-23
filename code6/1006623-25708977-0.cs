    string username = message.Substring(0, message.IndexOf(':') );
    string realMessage = message.Replace(username , "");
    serverChat.AppendText(message);
    serverChat.Select(((serverChat.Text.Length - message.Length)), username.Length );
    //..
