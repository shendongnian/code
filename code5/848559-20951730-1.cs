    _syslogSender = new SyslogUdpSender(server, port);
    _syslogSender = new SyslogRfc3164MessageSerializer();
    _syslogSender.Send(
        new SyslogMessage(
            notification.CreationTime, Facility.SecurityOrAuthorizationMessages1,
            GetSyslogMessageSeverity(notification.Level),
            Environment.MachineName,
            GeneralInformation.FullProductName,
            notification.Description.Replace("\n", " ")),
        _syslogSerializer)
