    using System.Data.Common;
    using System.Data.Entity;
    using System.Diagnostics;
    using NUnit.Framework;
    
    namespace efProviderChooser
    {
        public class MyThing
        {
            public int Id { get; set; }
        }
    
        public class MyContext : DbContext
        {
            public DbSet<MyThing> Things { get; set; }
        }
    
        public class Test
        {
            [Test]
            public void CanGetProvider()
            {
                var context = new MyContext();          
                var dbProviderFactory = DbProviderFactories
                                         .GetFactory(
                                           context.Database.Connection);
    
                Debug.WriteLine(dbProviderFactory.GetType());
                //gives one of 
                //System.Data.EntityClient.EntityProviderFactory
                //System.Data.Odbc.OdbcFactory
                //System.Data.OleDb.OleDbFactory
                //System.Data.OracleClient.OracleClientFactory
                //System.Data.SqlClient.SqlClientFactory
                //this list could change!
    
                // here I get SqlClient
                Assert.That(dbProviderFactory.GetType().ToString().Contains("SqlClient"));
            }
        }
    }
