        [TestMethod]
        [DeploymentItem(@"Testfiles\Customers.xml")]
        [DeploymentItem(@"Testfiles\Products.xml")]
        public void RecordsAreReturnedWhenUsingStoredProc()
        {
            Database db = DatabaseFactory.CreateDatabase("OracleTest");
            string spName = "GetCustomersView";
            using (IDataReader reader = db.ExecuteReader(CommandType.StoredProcedure, spName))
            {
                int columns = dsCustomers.Tables[0].Columns.Count;
                int i = 0;
                while (reader.Read())
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Assert.AreEqual(dsCustomers.Tables[0].Rows[i][j].ToString().Trim(), reader[j].ToString().Trim());
                    }
                    i++;
                }
            }
        }
