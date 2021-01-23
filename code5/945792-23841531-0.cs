    //To bind Dropdown list 
        protected Dictionary<int, string> GenerateDictionaryForDropDown(DataTable dtSource, string keyColumnName, string valueColumnName)
        {
            return dtSource.AsEnumerable()
              .ToDictionary<DataRow, int, string>(row => row.Field<int>(keyColumnName),
                                        row => row.Field<string>(valueColumnName));
        }
