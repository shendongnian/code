    `<system.serviceModel>
    <services>
      <service name="MyNamespace.MyService" behaviorConfiguration="NoHelpPageBehavior">
        <endpoint address="" binding="basicHttpBinding" contract="MyNamespace.IMyContract" />
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="NoHelpPageBehavior">
          <serviceDebug httpHelpPageEnabled="false" httpsHelpPageEnabled="false"/>
        </behavior>
      </serviceBehaviors>
    </behaviors>
