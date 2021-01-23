    Log Name:      Application
    Source:        .NET Runtime
    Date:          1/21/2014 9:09:23 AM
    Event ID:      1026
    Task Category: None
    Level:         Error
    Keywords:      Classic
    User:          N/A
    Computer:      DUDELT
    Description:
    Application: MyApp.exe
    Framework Version: v4.0.30319
    Description: The process was terminated due to an unhandled exception.
    Exception Info: System.ServiceModel.AddressAlreadyInUseException
    Stack:
       at System.ServiceModel.Channels.TransportManager.Open(System.ServiceModel.Channels.TransportChannelListener)
       at System.ServiceModel.Channels.TransportManagerContainer.Open(System.ServiceModel.Channels.SelectTransportManagersCallback)
       at System.ServiceModel.Channels.TransportChannelListener.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.ConnectionOrientedTransportChannelListener.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.TcpChannelListener`2[[System.__Canon, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.__Canon, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]].OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.Channels.ReliableChannelListenerBase`1[[System.__Canon, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]].OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.Dispatcher.ChannelDispatcher.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.ServiceHostBase.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open()
       at MyApp32.MyApp32.Main()
       at System.Threading.ThreadHelper.ThreadStart_Context(System.Object)
       at System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
       at System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
       at System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)
       at System.Threading.ThreadHelper.ThreadStart()
    
    Event Xml:
    <Event xmlns="http://schemas.microsoft.com/win/2004/08/events/event">
      <System>
        <Provider Name=".NET Runtime" />
        <EventID Qualifiers="0">1026</EventID>
        <Level>2</Level>
        <Task>0</Task>
        <Keywords>0x80000000000000</Keywords>
        <TimeCreated SystemTime="2014-01-21T14:09:23.000000000Z" />
        <EventRecordID>287767</EventRecordID>
        <Channel>Application</Channel>
        <Computer>DUDELT</Computer>
        <Security />
      </System>
      <EventData>
        <Data>Application: MyApp.exe
    Framework Version: v4.0.30319
    Description: The process was terminated due to an unhandled exception.
    Exception Info: System.ServiceModel.AddressAlreadyInUseException
    Stack:
       at System.ServiceModel.Channels.TransportManager.Open(System.ServiceModel.Channels.TransportChannelListener)
       at System.ServiceModel.Channels.TransportManagerContainer.Open(System.ServiceModel.Channels.SelectTransportManagersCallback)
       at System.ServiceModel.Channels.TransportChannelListener.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.ConnectionOrientedTransportChannelListener.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.TcpChannelListener`2[[System.__Canon, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.__Canon, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]].OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.Channels.ReliableChannelListenerBase`1[[System.__Canon, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]].OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.Dispatcher.ChannelDispatcher.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.ServiceHostBase.OnOpen(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open(System.TimeSpan)
       at System.ServiceModel.Channels.CommunicationObject.Open()
       at MyApp32. MyApp 32.Main()
       at System.Threading.ThreadHelper.ThreadStart_Context(System.Object)
       at System.Threading.ExecutionContext.RunInternal(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
       at System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object, Boolean)
       at System.Threading.ExecutionContext.Run(System.Threading.ExecutionContext, System.Threading.ContextCallback, System.Object)
       at System.Threading.ThreadHelper.ThreadStart()
    </Data>
      </EventData>
    </Event>
    Log Name:      Application
    Source:        Application Error
    Date:          1/21/2014 9:09:23 AM
    Event ID:      1000
    Task Category: (100)
    Level:         Error
    Keywords:      Classic
    User:          N/A
    Computer:      DUDELT
    Description:
    Faulting application name: MyApp.exe, version: 0.0.0.0, time stamp: 0x52dd9b89
    Faulting module name: KERNELBASE.dll, version: 6.1.7601.18229, time stamp: 0x51fb1116
    Exception code: 0xe0434352
    Fault offset: 0x0000c41f
    Faulting process id: 0x3ac0
    Faulting application start time: 0x01cf16b23d49d636
    Faulting application path: C:\MyApp\MyApp\bin\Debug\MyApp.exe
    Faulting module path: C:\Windows\syswow64\KERNELBASE.dll
    Report Id: a0b3e605-82a5-11e3-ab71-0021cc6f2033
    Event Xml:
    <Event xmlns="http://schemas.microsoft.com/win/2004/08/events/event">
      <System>
        <Provider Name="Application Error" />
        <EventID Qualifiers="0">1000</EventID>
        <Level>2</Level>
        <Task>100</Task>
        <Keywords>0x80000000000000</Keywords>
        <TimeCreated SystemTime="2014-01-21T14:09:23.000000000Z" />
        <EventRecordID>287768</EventRecordID>
        <Channel>Application</Channel>
        <Computer>DUDELT</Computer>
        <Security />
      </System>
      <EventData>
        <Data>MyApp.exe</Data>
        <Data>0.0.0.0</Data>
        <Data>52dd9b89</Data>
        <Data>KERNELBASE.dll</Data>
        <Data>6.1.7601.18229</Data>
        <Data>51fb1116</Data>
        <Data>e0434352</Data>
        <Data>0000c41f</Data>
        <Data>3ac0</Data>
        <Data>01cf16b23d49d636</Data>
        <Data>C:\code\MyApp\MyApp\bin\Debug\MyApp.exe</Data>
        <Data>C:\Windows\syswow64\KERNELBASE.dll</Data>
        <Data>a0b3e605-82a5-11e3-ab71-0021cc6f2033</Data>
      </EventData>
    </Event>
