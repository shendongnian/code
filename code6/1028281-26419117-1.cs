            //Deleting empty records from Datset
            foreach (DataTable source in result.Tables)
            {
                for (int i = 0; i < source.Rows.Count; i++)
                {
                    DataRow currentRow = source.Rows[i];
                    bool isEmpty = false;
                    foreach (var colValue in currentRow.ItemArray)
                    {
                        if (!string.IsNullOrEmpty(colValue.ToString()))
                        {
                            isEmpty = false;
                            break;
                        }
                        else
                            isEmpty = true;
                    }
                    if (isEmpty)
                        source.Rows[i].Delete();
                }
            }
            result.AcceptChanges();
