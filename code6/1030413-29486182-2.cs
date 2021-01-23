    <system.serviceModel>
    <bindings>
      <basicHttpBinding>
        <binding maxReceivedMessageSize="2147483647" sendTimeout="00:10:00" receiveTimeout="00:10:00">
          <readerQuotas maxStringContentLength="2147483647" maxArrayLength="2147483647" maxBytesPerRead="2147483647"/>
        </binding>
      </basicHttpBinding>
    </bindings>
    <behaviors>
      <serviceBehaviors>
        <behavior>
          <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
          <serviceDebug includeExceptionDetailInFaults="true"/>
        </behavior>
      </serviceBehaviors>
    </behaviors>
    <protocolMapping>
      <add binding="basicHttpsBinding" scheme="https" />
    </protocolMapping>
    <serviceHostingEnvironment aspNetCompatibilityEnabled="false">
      <serviceActivations>
        <add factory ="WebService.NInjectServiceHostFactory" relativeAddress="TestServic.svc" service="WebService.Services.ServiceManager"/>
      </serviceActivations>
    </serviceHostingEnvironment>
