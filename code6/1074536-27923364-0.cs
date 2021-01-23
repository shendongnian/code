    <system.web>
        <compilation xdt:Transform="RemoveAttributes(debug)" />
        <httpModules>
          <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Extensibility.Web.RequestTracking.WebRequestTrackingModule, Microsoft.ApplicationInsights.Extensibility.Web"
               xdt:Transform="Insert"/>
        </httpModules>
    
      </system.web>
    
      <system.webServer>
        <modules>
          <remove name="ApplicationInsightsWebTracking" xdt:Transform="Insert"/>
          <add name="ApplicationInsightsWebTracking" type="Microsoft.ApplicationInsights.Extensibility.Web.RequestTracking.WebRequestTrackingModule, Microsoft.ApplicationInsights.Extensibility.Web" preCondition="managedHandler" xdt:Transform="Insert" />
        </modules>
    </system.webServer>
