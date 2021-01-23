    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    class ExecuteAddProduct {
        public static void Main() {
            SqlConnection mySqlConnection = new SqlConnection("server=localhost;database=Northwind;uid=sa;pwd=sa");
            mySqlConnection.Open();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText =
              "EXECUTE AddProduct @MyProductID OUTPUT, @MyProductName, " +
              "@MySupplierID, @MyCategoryID, @MyQuantityPerUnit, " +
              "@MyUnitPrice, @MyUnitsInStock, @MyUnitsOnOrder, " +
              "@MyReorderLevel, @MyDiscontinued";
    
            mySqlCommand.Parameters.Add("@MyProductID", SqlDbType.Int);
            mySqlCommand.Parameters["@MyProductID"].Direction = ParameterDirection.Output;
            mySqlCommand.Parameters.Add("@MyProductName", SqlDbType.NVarChar, 40).Value = "Widget";
            mySqlCommand.Parameters.Add("@MySupplierID", SqlDbType.Int).Value = 1;
            mySqlCommand.Parameters.Add("@MyCategoryID", SqlDbType.Int).Value = 1;
            mySqlCommand.Parameters.Add("@MyQuantityPerUnit", SqlDbType.NVarChar, 20).Value = "1 per box";
            mySqlCommand.Parameters.Add("@MyUnitPrice", SqlDbType.Money).Value = 5.99;
            mySqlCommand.Parameters.Add("@MyUnitsInStock", SqlDbType.SmallInt).Value = 10;
            mySqlCommand.Parameters.Add("@MyUnitsOnOrder", SqlDbType.SmallInt).Value = 5;
            mySqlCommand.Parameters.Add("@MyReorderLevel", SqlDbType.SmallInt).Value = 5;
            mySqlCommand.Parameters.Add("@MyDiscontinued", SqlDbType.Bit).Value = 1;
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("New ProductID = " + mySqlCommand.Parameters["@MyProductID"].Value);
            mySqlConnection.Close();
        }
    }
