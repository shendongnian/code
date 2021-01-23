    </system.web>
    <system.webServer>
        <modules runAllManagedModulesForAllRequests="true">
          <remove name="ScriptModule" />
          <add name="ScriptModule" preCondition="managedHandler"     type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        </modules>
        <handlers>
          <remove name="ScriptHandlerFactory"/>
          <add name="ScriptHandlerFactory" verb="*" path="*.asmx" preCondition="integratedMode" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
        </handlers>
      </system.webServer>
