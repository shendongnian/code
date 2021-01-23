    var configuration =
        new System.Text.StringBuilder().AppendLine("[ DEFAULT ]")
            .AppendLine("ConnectionType=initiator")
            .AppendLine("[SESSION]")
            .AppendLine("BeginString=FIX.4.4")
            .AppendLine("SenderCompID=Sender")
            .AppendLine("TargetCompID=Target")
            .AppendLine("Username=Gandalf")
            .AppendLine("Password=YouShallNotPass")
            .ToString();
    var settings = new SessionSettings(new System.IO.StringReader(configuration));
    var session = new SessionID("FIX.4.4", "Sender", "Target");
    var sender = settings.Get(session).GetString("SenderCompID"); // Returns Sender
    var user = settings.Get(session).GetString("Username"); // Returns Gandalf
    var pass = settings.Get(session).GetString("Password"); // Returns YouShallNotPass
