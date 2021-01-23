    <system.serviceModel>
        <diagnostics>
            <messageLogging logEntireMessage="true" logMalformedMessages="true" logMessagesAtServiceLevel="true" logMessagesAtTransportLevel="true" />
        </diagnostics>
    </system.serviceModel>
    <system.diagnostics>
        <sources>
            <source name="System.ServiceModel" switchValue="Information, ActivityTracing" propagateActivity="true">
                <listeners>
                    <add name="traceListener" type="System.Diagnostics.XmlWriterTraceListener" initializeData="C:\Temp\SvcLog\Traces.svclog" />
                </listeners>
            </source>
        </sources>
    </system.diagnostics>
