    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
    <session-factory>
      <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
      <property name="dialect">NHibernate.Dialect.MsSql2012Dialect</property>
      <property name="connection.driver_class">NHibernate.Driver.SqlClientDriver</property>
      <property name="connection.connection_string">Data Source=.\sqlexpress;Database=StackExchangeExample;Integrated Security=SSPI;</property>
      <mapping assembly="catsHibernate.code"/>
    </session-factory>
