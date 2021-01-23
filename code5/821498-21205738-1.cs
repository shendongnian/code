      <system.data>
        <DbProviderFactories>
          <add name="Npgsql Data Provider" 
               invariant="Npgsql" 
               description ="Data Provider for PostgreSQL" 
               type="Npgsql.NpgsqlFactory, Npgsql" />
        </DbProviderFactories>
      </system.data>
    
      <connectionStrings>
        <add name="PostgreSQL" 
             providerName="Npgsql" 
             connectionString="Server=asdf;Port=5432;User Id=asdf;Password=asdf;Database=asdf;enlist=true" />
      </connectionStrings>
     
      <entityFramework>
        <providers>
          <provider invariantName="Npgsql" 
                    type="Npgsql.NpgsqlServices, Npgsql" />
        </providers>
      </entityFramework>
