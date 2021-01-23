        using System.Reflection;
        public void SetObjectProperties(object objClass, DataTable dataTable)
        {
            DataRow _dataRow = dataTable.Rows[0];
            Type objType = objClass.GetType();
            List<PropertyInfo> propertyList = new List<PropertyInfo>(objType.GetProperties());
            foreach (DataColumn dc in _dataRow.Table.Columns)
            {
                var _prop = propertyList.Where(a => a.Name == dc.ColumnName).Select(a => a).FirstOrDefault();
                if (_prop == null) continue;
                _prop.SetValue(objClass, Convert.ChangeType(_dataRow[dc], Nullable.GetUnderlyingType(_prop.PropertyType) ?? _prop.PropertyType), null);
            }
        }
