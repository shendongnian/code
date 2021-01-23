    <?xml version="1.0"?>
    <configuration>
      <configSections>
        <section name="instrumentationConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation.Configuration.InstrumentationConfigurationSection, Microsoft.Practices.EnterpriseLibrary.Common, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
        <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
      </configSections>
      <instrumentationConfiguration performanceCountersEnabled="false"
          eventLoggingEnabled="false" applicationInstanceName="TestApp" />
      <loggingConfiguration name="" tracingEnabled="true" defaultCategory="General">
        <listeners>
          <!-- Using DB Trace Listener because it's easy to make it fail -->
          <add name="Database Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.Database.FormattedDatabaseTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging.Database, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
              listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Database.Configuration.FormattedDatabaseTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging.Database, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
              databaseInstanceName="Database Connection String" writeLogStoredProcName="WriteLog"
              addCategoryStoredProcName="AddCategory" />
          <add name="Flat File Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
              listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
              fileName="error.log" />
          <add listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.CustomTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=5.0.505.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
              type="ConsoleApplication28.ExceptionThrowingTraceListener, ConsoleApplication28, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
              name="ExceptionThrowingTraceListener" />
        </listeners>
        <formatters />
        <categorySources>
          <add switchValue="All" name="General">
            <listeners>
              <add name="Database Trace Listener" />
            </listeners>
          </add>
        </categorySources>
        <specialSources>
          <allEvents switchValue="All" name="All Events" />
          <notProcessed switchValue="All" name="Unprocessed Category" />
          <errors switchValue="All" name="Logging Errors &amp; Warnings">
            <listeners>
              <add name="Flat File Trace Listener" />
              <add name="ExceptionThrowingTraceListener" />
            </listeners>
          </errors>
        </specialSources>
      </loggingConfiguration>
      <connectionStrings>
        <add name="Database Connection String" connectionString="database=mydb"
            providerName="System.Data.SqlClient" />
      </connectionStrings>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
      </startup>
    </configuration>
