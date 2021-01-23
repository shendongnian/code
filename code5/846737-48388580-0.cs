    <configuration>
        ...
        <connectionStrings>
	        <?blah ... ?>
            <add name="AppDb" ... />
	    ...
        </connectionStrings>
        ...
        <runtime>
            <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
                ...
                <dependentAssembly>
                    <assemblyIdentity name="WebGrease" publicKeyToken="31bf3856ad364e35" />
                    <bindingRedirect oldVersion="0.0.0.0-1.5.2.14234" newVersion="1.5.2.14234" />
                </dependentAssembly>
                ...
            </assemblyBinding>
        </runtime>
        ...
    </configuration>
