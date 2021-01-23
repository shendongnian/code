    using System;
        
        using System.Collections.Generic;
        
        using System.Data;
        
        using System.Data.SqlClient;
        
        using System.Linq;
        
        using System.Text;
        
        
        namespace InsertTeamIdIntoTable
        
        {
        
            class Program
        
            {
        
                const string str = @"Data Source=(localdb)\Projects;Initial Catalog=TestDb;Integrated Security=SSPI";
        
                static void Main(string[] args)
        
                {
        
        
                    InsertItemData(str);
        
                }
        
        
                private static void InsertItemData(string connectionString)
        
                {
        
                    string queryString =
        
                        "SELECT item1,item2,item3,item4 FROM dbo.table_items;";
        
        
                    using (SqlConnection connection =
        
                               new SqlConnection(connectionString))
        
                    {
        
                        SqlCommand command =
        
                            new SqlCommand(queryString, connection);
        
                        connection.Open();
        
        
                        SqlDataReader reader = command.ExecuteReader();
        
                        int itemId = 1;
        
                        //check if row has values in all(item 1,2,3,4) or three of the fields,
        
                        while (reader.Read())
        
                        {
        
                            bool flag = CheckValueNumber((IDataRecord)reader);
        
                            if (flag)
        
                            {
        
        
                                for (int i = 0; i < ((IDataRecord)reader).FieldCount; i++)
        
                                {
        
                                    string itemName = ((IDataRecord)reader)[i].ToString();
        
                                    if (string.IsNullOrWhiteSpace(itemName) == false)
        
                                    {
        
                                        if (CheckItemShelveExists(str, itemName))
        
                                        {
        
                                            if (CheckItemIdExists(str, itemName) == false)
        
                                            {
        
                                                UpdateTableItemShelves(str, itemId, itemName);
        
                                            }
        
                                        }
        
                                        else
        
                                        {
        
                                            InsertTableItemShelves(str, itemId, itemName);
        
                                        }
        
                                    }
        
                                }
        
                                itemId++;
        
                            }
        
                        }
        
                        reader.Close();
        
                    }
        
                }
        
        
                public static void UpdateTableItemShelves(string connectionString, int itemId, string itemName)
        
                {
        
                    string updateString = string.Format("Update dbo.table_item_shelves set item_id ={0} WHERE item_name ='{1}';", itemId, itemName);
        
        
                    using (SqlConnection connection =
        
                               new SqlConnection(connectionString))
        
                    {
        
                        SqlCommand command =
        
                            new SqlCommand(updateString, connection);
        
                        connection.Open();
        
        
                        command.ExecuteNonQuery();
        
        
                    }
        
                }
        
        
                public static void InsertTableItemShelves(string connectionString, int itemId, string itemName)
        
                {
        
                    string updateString = string.Format("Insert Into dbo.table_item_shelves(item_id,item_name) VALUES({0},'{1}');", itemId, itemName);
        
        
                    using (SqlConnection connection =
        
                               new SqlConnection(connectionString))
        
                    {
        
                        SqlCommand command =
        
                            new SqlCommand(updateString, connection);
        
                        connection.Open();
        
        
                        command.ExecuteNonQuery();
        
        
                    }
        
                }
        
        
        
                public static bool CheckItemShelveExists(string connectionString, string itemName)
        
                {
        
                    string updateString = string.Format("Select count(id) From dbo.table_item_shelves WHERE item_name ='{0}';", itemName);
        
        
                    using (SqlConnection connection =
        
                               new SqlConnection(connectionString))
        
                    {
        
                        SqlCommand command =
        
                            new SqlCommand(updateString, connection);
        
                        connection.Open();
        
        
                        return (Int32)command.ExecuteScalar() > 0;
        
        
                    }
        
                }
        
        
                public static bool CheckItemIdExists(string connectionString, string itemName)
        
                {
        
                    string updateString = string.Format("Select item_id From dbo.table_item_shelves WHERE item_name ='{0}';", itemName);
        
        
                    using (SqlConnection connection =
        
                               new SqlConnection(connectionString))
        
                    {
        
                        SqlCommand command =
        
                            new SqlCommand(updateString, connection);
        
                        connection.Open();
        
                        SqlDataReader reader = command.ExecuteReader();
        
        
                        while (reader.Read())
        
                        {
        
                            if (string.IsNullOrWhiteSpace(((IDataRecord)reader)[0].ToString()) == false)
        
                            {
        
                                return true;
        
                            }
        
                        }
        
        
                        reader.Close();
        
                        return false;
        
        
                    }
        
                }
        
        
                public static bool CheckValueNumber(IDataRecord record)
        
                {
        
                    int count = 0;
        
                    for (int i = 0; i < record.FieldCount; i++)
        
                    {
        
                        if (string.IsNullOrWhiteSpace(record[i].ToString()) == false)
        
                        {
        
                            count++;
        
                        }
        
                    }
        
                    return count >= 3;
        
                }
        
        
            }
        
        }
