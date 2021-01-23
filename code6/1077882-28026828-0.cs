    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    
      <configSections>
        <section name="hibernate-configuration"
                  type="NHibernate.Cfg.ConfigurationSectionHandler, NHibernate"/>
      </configSections>
      
        <startup>     
          <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
        </startup>
    
      <connectionStrings>  
        
        <add name="blog2" providerName="System.Data.SqlClient"
         connectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Elmodai\documents\visual studio 2013\Projects\Blog\Blog\DB1.mdf;Integrated Security=True"/>
       
        <add name="blog" providerName="System.Data.SqlClient"
         connectionString="Data Source=ELMODAI-PC;Initial Catalog=VamosVer;Integrated Security=True"/>
        
      </connectionStrings>
    
      <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
        <session-factory>
          <property name="connection.provider">
            NHibernate.Connection.DriverConnectionProvider
          </property>
    
          <property name="dialect">
            NHibernate.Dialect.MsSql2012Dialect
          </property>
    
          <property name="connection.driver_class">
            NHibernate.Driver.SqlClientDriver
          </property>
    
          <property name="connection.connection_string_name">
            blog
          </property>
    
          <property name="show_sql">
            ture
          </property>
    
          <property name="format_sql">
            ture
          </property>
    
          <property name="hbm2ddl.auto">
            update
          </property>
    
        </session-factory>
      </hibernate-configuration>
    
    </configuration>
