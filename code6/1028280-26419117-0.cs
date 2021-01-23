                //Deleting empty records from Dataset result 
                foreach (DataTable source in result.Tables)
                {
                    for (int i = source.Rows.Count; i >= 1; i--)
                    {
                        DataRow currentRow = source.Rows[i - 1];
                        foreach (var colValue in currentRow.ItemArray)
                        {
                            if (!string.IsNullOrEmpty(colValue.ToString()))
                                break;
    
                            // If we get here, all the columns are empty
                            source.Rows[i - 1].Delete();
                        }
                    }
                }
                result.AcceptChanges();
