    <connectionStrings>
       <add name="WebShopConfiguration" connectionString="myConString"/>
    </connectionStrings>
    <system.web>
       <httpModules>
         <add name="JsonLogger" type="ServiceModel.Logging.JsonLogger, ServiceModel"/>
        </httpModules>
    </system.web>
    <system.webServer>
       <modules>
          <add name="JsonLogger" type="ServiceModel.Logging.JsonLogger, ServiceModel"/>
       </modules>
    </system.webServer>
