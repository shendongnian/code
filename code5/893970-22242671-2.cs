    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    namespace BitsTest
    {
        [TestClass]
        public class BitsTester
        {
            [TestMethod]
            public void BitsTest()
            {
                // random seed for emulating bit-array file
                Random rand = new Random();
            
                DataTable table = new DataTable();
                table.Columns.Add("bit",typeof(bool));
                string cs = @"Data Source=(localdb)\v11.0;Initial Catalog=bittest;Integrated Security=True";
                // 2007040 records = 245kb of bits
                for (int i = 0; i < 2007040; i++)
                    table.Rows.Add(rand.Next() % 2 == 0);
                using (SqlBulkCopy bulk = new SqlBulkCopy(cs))
                {
                    bulk.DestinationTableName = "bits";
                    bulk.WriteToServer(table);
                }
            }
        }
    }
