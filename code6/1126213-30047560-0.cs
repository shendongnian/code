    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
      <session-factory>
        <property name="adonet.batch_size">5000</property>
        <property name="connection.driver_class">NHibernate.Driver.SQLite20Driver</property>
        <property name="connection.connection_string">Data Source=DBFile.db;Version=3;New=True;UseUTF8Encoding=True;</property>
        <property name="sql_exception_converter">DbExceptionConverter.SQLiteExceptionHandler.SqlExceptionConverter, DbExceptionConverter</property>
        <property name="dialect">NHibernate.Dialect.SQLiteDialect</property>
      </session-factory>
    </hibernate-configuration>
