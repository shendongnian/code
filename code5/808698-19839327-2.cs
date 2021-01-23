    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <section name="App.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
          <section name="DLLSample.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </sectionGroup>
      </configSections>
    
      <applicationSettings>        
        <App.Properties.Settings>
          <setting name="LogPath" serializeAs="String">
            <value>C:\Temp</value>
          </setting>
        </App.Properties.Settings>
        <DLLSample.Properties.Settings>
            <setting name="AllowStart" serializeAs="String">
                <value>True</value>
            </setting>
        </DLLSample.Properties.Settings>
      </applicationSettings>
    </configuration>
