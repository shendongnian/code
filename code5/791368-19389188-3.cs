    DataTable insertedBooks=new DataTable(); //We will use a new table to store all the cheched records
                insertedBooks = addedBooks.Clone();
                DataGridViewCheckBoxCell checkcell;
                foreach (DataGridViewRow row in dataGridViewAddedBooks.Rows)
                {               
                    checkcell = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (checkcell.Value.Equals(true))
                    {
                        insertedBooks.Rows.Add(row.Cells[1].Value.ToString(),row.Cells[2].Value.ToString(),row.Cells[3].Value.ToString(),Convert.ToInt32(row.Cells[4].Value),Convert.ToInt32(row.Cells[5].Value)); //Add all the checked records to insertedBooks table.
                    }                           
                }            
                SqlBulkCopy copy = new SqlBulkCopy(connection);
                copy.DestinationTableName = "Book";
                connection.Open();
                copy.WriteToServer(insertedBooks); //Use insertedBooks table to copy records to database table.
                addedBooks.Clear(); //Delete all data from addedBooks table, it also cleard the DataGridView.
