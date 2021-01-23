        <?xml version="1.0"?>
    
    <configuration>
      <appSettings/>
      <connectionStrings>
        <add connectionString="Server=XTREMEGOSPEL;Database=portfolioDB;Trusted_Connection=True" name="portDB" providerName="System.Data.SqlClient"/>
      </connectionStrings>
      <!--
        For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.
    
        The following attributes can be set on the <httpRuntime> tag.
          <system.Web>
            <httpRuntime targetFramework="4.5" />
          </system.Web>
      -->
      <system.web>
        <compilation debug="true" targetFramework="4.5.3">
          <assemblies>
            <add assembly="System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
          </assemblies>
        </compilation>
        <httpRuntime targetFramework="4.5" maxRequestLength="2097151"/>
        <authentication mode="Forms">
          <forms timeout="1440"/>
        </authentication>
        <sessionState timeout="1440"/>
        <pages controlRenderingCompatibilityVersion="3.5" clientIDMode="AutoID"/>
      </system.web>
      <system.webServer>
        <security>
          <requestFiltering>
            <requestLimits maxAllowedContentLength="4294967295"/>
          </requestFiltering>
        </security>
      </system.webServer>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="System.Web.Helpers" publicKeyToken="31bf3856ad364e35"/>
            <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0"/>
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="System.Web.WebPages" publicKeyToken="31bf3856ad364e35"/>
            <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0"/>
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>
