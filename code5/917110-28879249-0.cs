    <system.diagnostics>
    <trace autoflush="true">
    </trace>
    <sources>
      <source name="System.Net" tracemode="protocolonly" switchValue ="All">
        <listeners>
          <add name="log4net" />
        </listeners>
      </source>
      <source name="System.Net.Cache" tracemode="protocolonly" switchValue ="All">
        <listeners>
          <add name="log4net" />
        </listeners>
      </source>
      <source name="System.Net.Http" tracemode="protocolonly" switchValue ="All">
        <listeners>
          <add name="log4net" />
        </listeners>
      </source>
      <source name="System.Net.HttpListener" tracemode="protocolonly" switchValue ="All">
        <listeners>
          <add name="log4net" />
        </listeners>
      </source>
      <source name="System.Net.Sockets" tracemode="protocolonly" switchValue ="All">
        <listeners>
          <add name="log4net" />
        </listeners>
      </source>
      <source name="System.ServiceModel" propagateActivity="true" switchValue ="All">
        <listeners>
          <add name="log4net" />
        </listeners>
      </source>
      <source name="System.Web.Services.Asmx" switchValue ="All">
        <listeners>
          <add name="log4net" />
        </listeners>
      </source>
    </sources>
