     <system.serviceModel>
    <behaviors>
      <endpointBehaviors>
        <behavior name="WCFJSproxyDemo.Service.WCFJSproxyDemoBehavior">
          <enableWebScript/>
        </behavior>
      </endpointBehaviors>
      <serviceBehaviors>
        <behavior name="">
          <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true" />
          <serviceDebug includeExceptionDetailInFaults="false" />
        </behavior>
      </serviceBehaviors>   
    </behaviors>
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true"
      multipleSiteBindingsEnabled="true" />
    <services>
      <service name="WCFJSproxyDemo.Service.DataService">
        <!--<endpoint address="" behaviorConfiguration="WCFJSproxyDemo.Service.WCFJSproxyDemoBehavior" 
                  binding="webHttpBinding" contract="WCFJSproxyDemo.Service.IDemoWCFService">
        </endpoint>-->
		  <endpoint address="" behaviorConfiguration="WCFJSproxyDemo.Service.WCFJSproxyDemoBehavior"
				 binding="webHttpBinding" contract="WCFJSproxyDemo.Service.IDataService">
		  </endpoint>
      </service> 
    </services>
