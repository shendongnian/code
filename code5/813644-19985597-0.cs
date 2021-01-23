    <services>
        <service name="SparqlService.SparqlService" behaviorConfiguration="ServiceBehavior">
            <endpoint binding="webHttpBinding" contract="SparqlService.ISparqlService" behaviorConfiguration="webHttp" />
        </service>
    </services>
