                const string connectionString = str;
     
                DataTable DataTableAllWithoutID = new DataTable();
    #if !test
                string queryString = "select * from table_items_shelves;";
                SqlDataAdapter adapterAllWithoutID = new SqlDataAdapter(queryString, connectionString);
                adapterAllWithoutID.Fill(DataTableAllWithoutID);
                adapterAllWithoutID.Dispose();
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string insertString = "Update table_items_shelves Set Item_ID = @Item_ID where Item_Name = '@key';";
                SqlCommand insertCommand = new SqlCommand(insertString, connection);
                insertCommand.Parameters.Add("@Item_ID", SqlDbType.Int);
                insertCommand.Parameters.Add("@key", SqlDbType.NVarChar);
    #else
                DataTableAllWithoutID.Columns.Add("Item_Name", typeof(string));
                DataTableAllWithoutID.Columns.Add("Item_ID", typeof(object));
                foreach (List<object> row in input)
                {
                    DataRow newRow = DataTableAllWithoutID.Rows.Add();
                    newRow.ItemArray = row.ToArray();
                }
               
    #endif
                //this code will get empty items
                List<DataRow> nullOrEmpty = DataTableAllWithoutID.AsEnumerable()
                   .Where(x => x.Field<object>("Item_ID") == null)
                   .ToList();
                //this creates a dictionary of valid items
                Dictionary<int, List<DataRow>> dict = DataTableAllWithoutID.AsEnumerable()
                    .Where(x => x.Field<object>("Item_ID") != null)
                    .GroupBy(x => x.Field<object>("Item_ID"), x => x)
                    .ToDictionary(x => Convert.ToInt32(x.Key), x => (List<DataRow>)x.ToList());
                //create IEnumerator for the null items
                IEnumerator<DataRow> emptyRows = nullOrEmpty.GetEnumerator();
                Boolean noMoreEmptyRows = false;
                if (emptyRows != null)
                {
                    foreach (int key in dict.Keys)
                    {
                        Console.WriteLine(key.ToString());
                        //get count of items            
                        int count = dict[key].Count;
                        int itemID = (int)key;
                        for (int index = count; count < 8; count++)
                        {
                            if (emptyRows.MoveNext())
                            {
                                //get an item from the null list                  
                                emptyRows.Current["Item_ID"] = itemID;
                                insertCommand.Parameters["@Item_ID"].Value = itemID;
                                insertCommand.Parameters["@key"].Value = emptyRows.Current["Item_Name"];
                                insertCommand.ExecuteNonQuery();
                                Console.WriteLine("current item ID " + itemID);
                                Console.WriteLine("current count " + count);
                                //Console.ReadKey();
                            }//end if
                            else
                            {
                                noMoreEmptyRows = true;
                                break;
                            }//end else
                        }//end for
                        if (noMoreEmptyRows)
                            break;
                    }//end foreach
                    if (!noMoreEmptyRows)
                    {
                        //increment key to one greater than max value
                        int maxKey = dict.Keys.Max() + 1;
                        int count = 0;
                        while (emptyRows.MoveNext())
                        {
                            //get an item from the null list                  
                            emptyRows.Current["Item_ID"] = maxKey.ToString();
                            insertCommand.Parameters["@Item_ID"].Value = maxKey.ToString();
                            insertCommand.Parameters["@key"].Value = emptyRows.Current["Item_ID"];
                            
                                insertCommand.ExecuteNonQuery();
                            
                              count++;
                            if (count == 8)
                            {
                                maxKey++;
                                count = 0;
                            }
                        }
                    }
                }//end if
    #if test
                foreach (DataRow row in DataTableAllWithoutID.Rows)
                {
                    Console.WriteLine("Item_Name : {0}  Item ID :   {1}", 
                        row["Item_Name"], row["Item_ID"]);
                }
    #endif
     
                FIllGroupID(str);
                Console.ReadKey();
     
            }
