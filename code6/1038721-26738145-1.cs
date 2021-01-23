    <system.serviceModel>
      <extensions>
        <bindingElementExtensions>
          <add name="customTextMessageEncoding" type="Microsoft.ServiceModel.Samples.CustomTextMessageEncodingBindingSection, CustomTextMessageEncoder" />
        </bindingElementExtensions>
      </extensions>
      <bindings>
        <basicHttpBinding>
          <binding name="myBasicHttpBinding" receiveTimeout="00:10:00" closeTimeout="00:10:00" sendTimeout="00:10:00" openTimeout="00:10:00" maxBufferSize="2147483647" maxReceivedMessageSize="2147483647">
            <security mode="None" />
            <readerQuotas maxDepth="32" maxStringContentLength="2147483647"
              maxArrayLength="16348" maxBytesPerRead="4096" maxNameTableCharCount="16384" />
          </binding>
        </basicHttpBinding>
      </bindings>
      
      <services>
        <service name="OROC.Proxy.ProxyService" behaviorConfiguration="ServiceBehaviors">
          <endpoint name="Endpoint"
                    binding="basicHttpBinding"
                    bindingConfiguration="myBasicHttpBinding"
                    contract="OROC.Proxy.IProxyService" />
          <!--<endpoint kind="udpDiscoveryEndpoint" binding="ProxyService" />-->
        </service>
      </services>
      <behaviors>
        <serviceBehaviors>
          <behavior name="ServiceBehaviors">
            <serviceMetadata httpGetEnabled="true" httpsGetEnabled="false"/>
            <serviceDebug includeExceptionDetailInFaults="true"/>
            <dataContractSerializer maxItemsInObjectGraph="2147483647"/>
          </behavior>
        </serviceBehaviors>
      </behaviors>
      <serviceHostingEnvironment aspNetCompatibilityEnabled="true"/>
    </system.serviceModel>
