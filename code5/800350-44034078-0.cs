      <system.web>
        <compilation>
          <assemblies>
            <add assembly="System.Web.Mvc, Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
          </assemblies>
        </compilation>
    
        <pages pageParserFilterType="System.Web.Mvc.ViewTypeParserFilter, System.Web.Mvc, 
           Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
               pageBaseType="System.Web.Mvc.ViewPage, System.Web.Mvc, 
           Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
           userControlBaseType="System.Web.Mvc.ViewUserControl, System.Web.Mvc, 
           Version=5.2.3.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
               >
          <namespaces>
            <add namespace="System.Web.Mvc"/>
            <add namespace="System.Web.Mvc.Ajax"/>
            <add namespace="System.Web.Mvc.Html"/>
            <add namespace="System.Web.Routing"/>
          </namespaces>
        </pages>
      </system.web>
