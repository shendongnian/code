    <system.diagnostics>
      <sources>
         <source propagateActivity="true" name="System.ServiceModel" switchValue="Information, ActivityTracing">
            <listeners>
               <add name="ServiceModelMessageLoggingListener">
                  <filter type="" />
               </add>
            </listeners>
         </source>
         <source name="System.ServiceModel.MessageLogging" switchValue="Warning,ActivityTracing">
            <listeners>
               <add name="ServiceModelMessageLoggingListener">
                  <filter type="" />
               </add>
            </listeners>
         </source>
      </sources>
      <sharedListeners>
         <add initializeData="C:\temp\WCFLogs\ServerWCFTraces.svclog" type="System.Diagnostics.XmlWriterTraceListener, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" name="ServiceModelMessageLoggingListener" traceOutputOptions="Timestamp">
            <filter type="" />
         </add>
      </sharedListeners>
    </system.diagnostics>
