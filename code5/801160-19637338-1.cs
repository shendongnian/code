	<?xml version="1.0" encoding="utf-8"?>
	<!-- 
	This template was written to work with NHibernate.Test.
	Copy the template to your NHibernate.Test project folder and rename it in hibernate.cfg.xml and change it 
	for your own use before compile tests in VisualStudio.
	-->
	<!-- This is the ByteFX.Data.dll provider for MySql -->
	<hibernate-configuration  xmlns="urn:nhibernate-configuration-2.2" >
		<session-factory name="NHibernate.Test">
			<property name="connection.driver_class">NHibernate.Driver.MySqlDataDriver</property>
			<property name="connection.connection_string">
		  Data Source=127.0.0.1;Port=3307;MyUser Id=root;Password=MyPassword;Database=MyDatabase;
		</property>
			<property name="dialect">NHibernate.Dialect.MySQLDialect</property>
		</session-factory>
	</hibernate-configuration>
