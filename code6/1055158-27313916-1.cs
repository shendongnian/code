    <system.web>
      <authorization>
        <allow users="*"/>
      </authorization>
      <!-- [04/12/2014 SS] added to get over ASP parser failing to recognise script manager -->
      <pages>
        <controls>
          <add tagPrefix="asp" namespace="System.Web.UI" assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
          <add tagPrefix="asp" namespace="System.Web.UI.WebControls" assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"/>
        </controls>
      </pages>
      <!-- [end] -->
    </system.web>
