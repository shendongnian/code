    <system.web>
        <httpRuntime maxRequestLength="30000" />
    </system.web>
    
    <system.webServer>
        <security>
          <requestFiltering>
            <requestLimits maxAllowedContentLength="30000" />
          </requestFiltering>
        </security>
    </system.webServer>
