    <?xml version="1.0" encoding="UTF-8"?>
    <configuration>
        <system.web>
            <compilation debug="true" targetFramework="4.0" />
        </system.web>
        <system.serviceModel>
            <services>
                <service name="SparqlService.SparqlService" behaviorConfiguration="ServiceBehavior">
                    <endpoint binding="webHttpBinding" contract="SparqlService.ISparqlService" behaviorConfiguration="webHttp" />
                </service>
            </services>
            <behaviors>
                <serviceBehaviors>
                    <behavior name="ServiceBehavior">
                        <serviceMetadata httpGetEnabled="true" />
                        <serviceDebug includeExceptionDetailInFaults="false" />
                    </behavior>
                    <behavior>
                        <!-- To avoid disclosing metadata information, set the value below to false and remove the metadata endpoint above before deployment -->
                        <serviceMetadata httpGetEnabled="true" />
                        <!-- To receive exception details in faults for debugging purposes, set the value below to true.  Set to false before deployment to avoid disclosing exception information -->
                        <serviceDebug includeExceptionDetailInFaults="false" />
                    </behavior>
                </serviceBehaviors>
                <endpointBehaviors>
                    <behavior name="webHttp">
                        <webHttp />
                    </behavior>
                </endpointBehaviors>
            </behaviors>
        </system.serviceModel>
        <system.webServer>
            <modules runAllManagedModulesForAllRequests="true" />
        </system.webServer>
    </configuration>
