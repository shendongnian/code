        public class GridHelper
        {
        private DataTable baseDt;
        public GridHelper(string tableName)
        {
            baseDt = new DataTable(tableName);
        }
        public DataTable getDataTable()
        {
            return baseDt;
        }
        public object[,] getObjToFill()
        {
            object[,] obj = new object[baseDt.Columns.Count, 2];
            for (int i = 0; i < baseDt.Columns.Count; i++)
            {
                obj[i, 0] = baseDt.Columns[i].ColumnName;
            }
            return obj;
        }
        public void addColumn(string colName, Type valueType)
        {
            baseDt.Columns.Add(colName, valueType);
        }
        public void addRow(object[,] values)
        {
            DataRow newRow = baseDt.NewRow();
            for (int i = 0; i < values.Length / 2; i++)
            {
                bool colFound = false;
                for (int j = 0; j < baseDt.Columns.Count; j++)
                {
                    if (baseDt.Columns[j].ColumnName == values[i, 0].ToString())
                    {
                        colFound = true;
                        break;
                    }
                }
                if (colFound == false)
                {
                    throw new Exception("The column " + values[i, 0].ToString() + " has not been added yet.");
                }
                newRow[values[i, 0].ToString()] = values[i, 1];
            }
            baseDt.Rows.Add(newRow);
        }
        public static DataTable LINQToDataTable<T>(T objToList) where T : System.Collections.IList
        {
            GridHelper ghResult = new GridHelper("Report");
            foreach (Object item in objToList)
            {
                var props = item.GetType().GetProperties();
                foreach (var prop in props)
                {
                    ghResult.addColumn(prop.Name, typeof(string));
                    //prop.Name
                    //prop.GetValue(item)
                }
                break;
            }
            object[,] obj = ghResult.getObjToFill();
            foreach (Object item in objToList)
            {
                var props = item.GetType().GetProperties();
                int index = 0;
                foreach (var prop in props)
                {
                    //ReportValue(prop.Name, prop.GetValue(item, null));
                    //prop.Name
                    obj[index, 1] = prop.GetValue(item);
                    index++;
                }
                ghResult.addRow(obj);
            }
            return ghResult.getDataTable();
        }
        }
