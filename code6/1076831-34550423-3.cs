    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Data.Db;
    using System.Linq;
    namespace UnitTestProject
    {
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void Test()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "Dynamic Data Source",
                UserID = "Dynamic User ID",
                Password = "Dynamic Password"
            };
            using (var context = new OracleBlogModel(sqlConnectionStringBuilder.ToString()))
            {
                var data = context.Blogs.ToList();
            }
        }
    }
