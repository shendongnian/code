    <system.serviceModel>
       <behaviors>
          <serviceBehaviors>
             <behavior name="MyServiceBehavior">
                 <serviceDebug includeExceptionDetailInFaults="False" />
             </behavior>
          </serviceBehaviors>
       </behaviors>
    
       <services>
          <service name="MyService"
                   behaviorConfiguration="MyServiceBehavior" >
              ....
          </service>
       </services>
    </system.serviceModel>
