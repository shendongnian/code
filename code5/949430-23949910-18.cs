    var b = new CommandBuilder();
    b.Register("SysEv01", setting => {
        var sysEvent = new SysEventCommand();
        sysEvent.Type = setting.Properties["Type"];
        sysEvent.OutPort = setting.Properties["Out"];
        return sysEvent;
    
    });
