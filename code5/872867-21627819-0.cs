    <configuration>
      <configSections>
        ... references to all dll settings ...
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
          <section name="MyAssemblyNamespace.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      ... more config stuff...
      <applicationSettings>
        ... override your dll settings ...
        <MyAssemblyNamespace.Properties.Settings>
           <setting name="MaxUserNameLength" serializeAs="String">
              <value>100</value>
           </setting>
        </MyAssemblyNamespace.Properties.Settings>
      </applicationSettings>
