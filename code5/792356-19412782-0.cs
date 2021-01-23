    <system.diagnostics>
    <sources>
      <source name="System.ServiceModel.MessageLogging" switchValue="Warning, ActivityTracing">
        <listeners>
          <add name="ServiceModelTraceListener" />
        </listeners>
      </source>
      <source name="System.ServiceModel" switchValue="Verbose,ActivityTracing">
        <listeners>
          <add name="ServiceModelTraceListener" />
        </listeners>
      </source>
      <source name="System.Runtime.Serialization" switchValue="Verbose,ActivityTracing">
        <listeners>
          <add name="ServiceModelTraceListener" />
        </listeners>
      </source>
    </sources>
    <sharedListeners>
      <add initializeData="App_tracelog.svclog" type="System.Diagnostics.XmlWriterTraceListener, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" name="ServiceModelTraceListener" traceOutputOptions="Timestamp" />
    </sharedListeners>
