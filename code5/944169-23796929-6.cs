    <system.diagnostics>
      <sources>
        <source name="System.ServiceModel.MessageLogging">
          <listeners>
            <clear />
            <add name="messages"
              type="System.Diagnostics.XmlWriterTraceListener"
              initializeData="c:\logs\messages.svclog" />
          </listeners>
        </source>
      </sources>
    </system.diagnostics>
