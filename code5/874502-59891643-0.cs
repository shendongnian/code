     public DataTable DynamicToDT(List<object> objects)
            {
                DataTable dt = new DataTable("StudyRecords"); // Runtime Datatable          
                string[] arr = { "Name", "Department", "CollegeName", "Address" };// Column Name for DataTable
                if (objects != null && objects.Count > 0)
                {
                    for (int i = 0; i < objects.Count; i++)
                    {
                        dt.Columns.Add(arr[i]);
                        if (i == 0)
                        {
                            var items = objects[0] as IEnumerable<string>;
                            foreach (var itm in items)
                            {
                                DataRow dr1 = dt.NewRow(); // Adding values to Datatable  
                                dr1[arr[i]] = itm;
                                dt.Rows.Add(dr1);
                            }
                        }
                        else
                        {
                            var items = objects[i] as IEnumerable<string>;
                            int count = 0;
                            foreach (var itm in items)
                            {
                                dt.Rows[count][arr[i]] = itm;
                                count++;
                            }
                        }
                    }
    
                    return dt; // Converted Dynamic list to Datatable  
                }
                return null;
            }
