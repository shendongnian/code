    <system.serviceModel>
        <services>
            <service name="Nelibur.ServiceModel.Services.JsonServicePerCall">
                <host>
                    <baseAddresses>
                        <add baseAddress="http://*:9095/feedback" />
                    </baseAddresses>
                </host>
                <endpoint binding="webHttpBinding"
                          contract="Nelibur.ServiceModel.Contracts.IJsonService" />
            </service>
        </services>
    </system.serviceModel>
