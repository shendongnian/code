    <system.serviceModel>
        <services>
            <service name="PayrollService.Service1Behavior"
                     behaviorConfiguration="ServiceBehaviour">
                <endpoint address="" binding="webHttpBinding"
                          contract="PayrollService.IPayrollRest"
                          behaviorConfiguration="web"/>
            </service>
        </services>
        <behaviors>
            <serviceBehaviors>
                <behavior name="ServiceBehaviour">
                    <serviceMetadata httpGetEnabled="true"/>
                    <serviceDebug includeExceptionDetailInFaults="false"/>
                </behavior>
            </serviceBehaviors>
            <endpointBehaviors>
                <behavior name="web">
                    <webHttp/>
                </behavior>
            </endpointBehaviors>
        </behaviors>
    </system.serviceModel>
