        internal static class ExtentsionHelpers
    {
        public static DataSet ToDataSet<T>(this List<RootObject> list)
        {
            try
            {
                Type elementType = typeof(RootObject);
                DataSet ds = new DataSet();
                DataTable t = new DataTable();
                ds.Tables.Add(t);
                try
                {
                    //add a column to table for each public property on T
                    foreach (var propInfo in elementType.GetProperties())
                    {
                        try
                        {
                            Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                                t.Columns.Add(propInfo.Name, ColType);
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                try
                {
                    //go through each property on T and add each value to the table
                    foreach (RootObject item in list)
                    {
                        DataRow row = t.NewRow();
                        foreach (var propInfo in elementType.GetProperties())
                        {
                            row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                        }
                        t.Rows.Add(row);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                insert.insertCategories(t);
                return ds.
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
    };
