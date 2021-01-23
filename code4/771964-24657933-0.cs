    using MvcMyDefaultDatabase.Models;
    using System.Data.Metadata.Edm;
    using System.Data.SqlClient;
    using System.Data.EntityClient;
    using System.Configuration;
    using System.Reflection;
        public ActionResult List(string Schema)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            MetadataWorkspace workspace = new MetadataWorkspace(new string[] { "res://*/" }, new Assembly[] { Assembly.GetExecutingAssembly() });
            EntityConnection entityConnection = new EntityConnection(workspace, sqlConnection);
            sqlConnection.Open();
            sqlConnection.ChangeDatabase(Schema);
            Models.MyEntities db = new MyEntities(entityConnection);
            List<MyTableRecords> MyTableRecordsList = db.MyTableRecords.ToList();
            return View(MyTableRecordsList);
        }
