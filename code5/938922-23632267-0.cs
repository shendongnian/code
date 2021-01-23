      <appSettings>
        <add key="ChartImageHandler" value="storage=file;timeout=20;" />
      </appSettings>
    
      <system.web>
        <compilation debug="true" targetFramework="4.0">
          <assemblies>
            <add assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
          </assemblies>
        </compilation>
      </system.web>
      <system.webServer>
        <handlers>
          <add name="ChartImg" verb="*" path="ChartImg.axd"  type="System.Web.UI.DataVisualization.Charting.ChartHttpHandler, System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"  />
        </handlers>
      </system.webServer>
