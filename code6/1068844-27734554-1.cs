    <system.diagnostics>
        <switches>
          <add name="XmlSerialization.Compilation" value="4"/>
      </switches>
       <sources>
          <source name="System.ServiceModel" switchValue="Information, ActivityTracing" propagateActivity="true">
            <listeners>
              <add name="xml" />
            </listeners>
          </source>
          <source name="System.ServiceModel.MessageLogging">
            <listeners>
              <add name="xml" />
            </listeners>
          </source>
        </sources>
        <sharedListeners>
          <add name="xml" type="System.Diagnostics.XmlWriterTraceListener" initializeData="c:\temp\wcfServiceLog.svc" />
        </sharedListeners>
      </system.diagnostics>
