     <system.serviceModel>
        <behaviors>
          <endpointBehaviors>
            <behavior name="Tajan.Web.UI.Services.UserServiceAspNetAjaxBehavior">
              <enableWebScript />
          </endpointBehaviors>
          <serviceBehaviors>
            <behavior name="debug">
              <serviceDebug includeExceptionDetailInFaults="true" />
            </behavior>
          </serviceBehaviors>
       </behaviors>
    
     <services>
          <service behaviorConfiguration="debug" name="YOUR_SERVICE_CLASS">
            <endpoint address="" behaviorConfiguration="YOUR_SERVICE_CLASS_Behavior" binding="webHttpBinding" contract="YOUR_SERVICE_CLASS_INTERFACE" />
          </service>
    
        </services>
      </system.serviceModel>
