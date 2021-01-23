    [TestClass]
    [DeploymentItem("Resources\\empty-db.sqlite", "Resources")]
    [DeploymentItem("x64\\SQLite.Interop.dll", "x64")]
    [DeploymentItem("x86\\SQLite.Interop.dll", "x86")]
    public class SQLiteTest
    {
        [TestInitialize()]
        public void ClearDatabase()
        {
            File.Copy("Resources\\empty-db.sqlite", "test-db.sqlite", true);
        }
    }
