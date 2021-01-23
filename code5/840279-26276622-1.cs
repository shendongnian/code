        <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
      </configSections>
      <loggingConfiguration name="" tracingEnabled="true" defaultCategory="General">
        <listeners>
          <add listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.CustomTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                    type="EnterpriseLibrary.Sample1.MyCustomMsmqTraceListener, EnterpriseLibrary.Sample1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                     name="MyCustomMsmqTraceListener"
                    formatter="Text Formatter" />
        </listeners>
        <formatters>
          <add type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
              template="Timestamp: {timestamp}{newline}
