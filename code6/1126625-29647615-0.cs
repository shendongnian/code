    <?xml version="1.0" encoding="utf-8"?>
    <!--
      For more information on how to configure your ASP.NET application, please visit
      http://go.microsoft.com/fwlink/?LinkId=169433
      -->
    <configuration>
      <configSections>
        <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <system.webServer>
        <validation validateIntegratedModeConfiguration="false" />
        <handlers>
          <remove name="ChartImageHandler" />
          <add name="ChartImageHandler" preCondition="integratedMode" verb="GET,HEAD,POST" path="ChartImg.axd" type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
        </handlers>
      </system.webServer>
      <connectionStrings>
      database connections---
      </connectionStrings>
      <system.web>
        <httpHandlers>
          <add path="ChartImg.axd" verb="GET,HEAD,POST" type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" validate="false" />
        </httpHandlers>
        <pages>
          <controls>
            <add tagPrefix="asp" namespace="System.Web.UI.DataVisualization.Charting" assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
          <add tagPrefix="ajaxToolkit" assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" /></controls>
        </pages>
        <compilation debug="true" targetFramework="4.5">
          <assemblies>
            <add assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
            <add assembly="AjaxControlToolkit, Version=4.5.7.1213, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
          </assemblies>
        </compilation>
        <httpRuntime targetFramework="4.5" />
        <!--<authentication mode="Forms">
          <forms defaultUrl="~/default.aspx" loginUrl="~/Login.aspx" slidingExpiration="true" timeout="20" />
        </authentication>-->
        <!--Start of windows authentication -->
        <authentication mode="Windows" />
         
           <authorization>
         		roles
    	   <deny users="*" />
          </authorization>
    
        <roleManager defaultProvider="WindowsProvider" enabled="true" cacheRolesInCookie="false">
          <providers>
            <add name="WindowsProvider" type="System.Web.Security.WindowsTokenRoleProvider" />
          </providers>
        </roleManager>
        <!--<pages>
          <namespaces>
            <add namespace="System.Web.Optimization" />
          </namespaces>
          <controls>
            <add assembly="Microsoft.AspNet.Web.Optimization.WebForms" namespace="Microsoft.AspNet.Web.Optimization.WebForms" tagPrefix="webopt" />
          </controls>
        </pages>-->
        
        <sessionState timeout="120"></sessionState>
      </system.web>
      <appSettings>
        <add key="ValidationSettings:UnobtrusiveValidationMode" value="None" />
        <add key="ChartImageHandler" value="storage=file;timeout=20;dir=C:\TempImageFiles\;" />
      </appSettings>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="WebGrease" publicKeyToken="31bf3856ad364e35" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-1.5.2.14234" newVersion="1.5.2.14234" />
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="Microsoft.WindowsAzure.Storage" publicKeyToken="31bf3856ad364e35" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-2.1.0.4" newVersion="2.1.0.4" />
          </dependentAssembly>
          <dependentAssembly>
            <assemblyIdentity name="HtmlAgilityPack" publicKeyToken="bd319b19eaf3b43a" culture="neutral" />
            <bindingRedirect oldVersion="0.0.0.0-1.4.9.0" newVersion="1.4.9.0" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="v11.0" />
          </parameters>
        </defaultConnectionFactory>
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
      </entityFramework>
      <system.serviceModel>
        <behaviors>
          <endpointBehaviors>
            <behavior name="App.AdminSvcAspNetAjaxBehavior">
              <enableWebScript />
            </behavior>
            <behavior name="App.secure.Admin.AdminAspNetAjaxBehavior">
              <enableWebScript />
            </behavior>
          </endpointBehaviors>
        </behaviors>
        <serviceHostingEnvironment aspNetCompatibilityEnabled="true"
          multipleSiteBindingsEnabled="true" />
        <services>
          <service name="App.AdminSvc">
            <endpoint address="" behaviorConfiguration="App.AdminSvcAspNetAjaxBehavior"
              binding="webHttpBinding" contract="App.AdminSvc" />
          </service>
          <service name="App.secure.Admin.Admin">
            <endpoint address="" behaviorConfiguration="App.secure.Admin.AdminAspNetAjaxBehavior"
              binding="webHttpBinding" contract="App.secure.Admin.Admin" />
          </service>
        </services>
      </system.serviceModel>
    </configuration>
