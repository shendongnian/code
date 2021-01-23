        <system.serviceModel>
            <services>
                <service name="WcfService1.Service">
                    <endpoint address="" binding="webHttpBinding" contract="WcfService1.IService"/>
                </service>
            </services>
            <behaviors>
                <serviceBehaviors>
                    <behavior>
                        <serviceMetadata httpGetEnabled="true" httpsGetEnabled="true"/>
                        <serviceDebug includeExceptionDetailInFaults="true"/>
                    </behavior>
                </serviceBehaviors>
                <endpointBehaviors>
                    <behavior>
                        <webHttp/>
                    </behavior>
                </endpointBehaviors>
            </behaviors>
            <serviceHostingEnvironment>
                <serviceActivations>
                    <add factory="System.ServiceModel.Activation.ServiceHostFactory" relativeAddress="./sayhello.svc" service="WcfService1.Service"/>
                </serviceActivations>
            </serviceHostingEnvironment>
        </system.serviceModel>
