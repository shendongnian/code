    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="dataConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Data.Configuration.DatabaseSettings, Microsoft.Practices.EnterpriseLibrary.Data, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
      </configSections>
    
      <dataConfiguration defaultDatabase="MainConnectionString">
    
    
    
    <connectionStrings>
    
      <!-- Sql Server(s) -->
      <add name="MainConnectionString" connectionString="Server=.\MyInstance;Database=pubs;Trusted_Connection=True;"
           providerName="System.Data.SqlClient"/>
    
    
    </connectionStrings>
