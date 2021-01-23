    <configuration>
      <configSections>
        <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true"/>
      </configSections>
      <loggingConfiguration name="" tracingEnabled="true" defaultCategory="General">
        <listeners>
          <add name="Email Trace Listener"
               type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.EmailTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
               listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.EmailTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
               toAddress="xyz@gmail.com" fromAddress="abc@gmail.com" subjectLineStarter="Exception Occured" smtpServer="smtp.gmail.com" smtpPort="587"
               formatter="Text Formatter" authenticationMode="UserNameAndPassword" useSSL="true" userName="abc@gmail.com" password="********"/>
          <add name="Flat File Trace Listener"
               type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
               listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
               fileName="trace.log"/>
        </listeners>
        <formatters>
          <add type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
               template="Timestamp: {timestamp}{newline}
