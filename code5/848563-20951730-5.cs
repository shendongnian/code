    _syslogSender = new SyslogUdpSender("localhost",514);
    _syslogSender.Send(
        new SyslogMessage(
            DateTime.Now,
            Facility.SecurityOrAuthorizationMessages1,
            Severity.Informational,
            Environment.MachineName,
            "Application Name",
            "Message Content"),
        new SyslogRfc3164MessageSerializer());
