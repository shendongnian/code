    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
      <session-factory>
        <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
        <property name="dialect">NHibernate.Dialect.PostgreSQLDialect</property>
        <property name="connection.driver_class">NHibernate.Driver.NpgsqlDriver</property>
        <property name="connection.connection_string">Server=127.0.0.1;Port=5432;Database=DbName;User Id=postgres;Password=postgres;</property>
        <property name="sql_exception_converter">DbExceptionConverter.PostgresExceptionHandler.SqlExceptionConverter, DbExceptionConverter</property>
      </session-factory>
    </hibernate-configuration>
