    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
    <session-factory>
    <property name="dialect">NHibernate.Dialect.MySQLDialect</property>
    <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
    <property name="connection.driver_class">NHibernate.Driver.MySqlDataDriver</property>
    <property name="connection.connection_string">connectionstring</property>
    <property name='proxyfactory.factory_class'>NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle</property>
    <mapping assembly="Mcgvd" />
    </session-factory>
    </hibernate-configuration>
