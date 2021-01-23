    // another web.config section "<connectionStrings>"
    <connectionStrings>
      <add name="MyName" 
        connectionString="Server=localhost;Database=mohit;User ID=root;Password=root" />
    </connectionStrings>
    // here we reference the name defined in the other section
    <session-factory>
        ...
        <property name="connection.connection_string_name">MyName</property>
