    private static ObservableCollection<GenericObject> Convert(DataTable toConvert)
    {
        ObservableCollection<GenericObject> _result = new ObservableCollection<GenericObject>();
        foreach (DataRow _row in toConvert.Rows)
        {
            GenericObject _genericObject = new GenericObject();
            foreach (DataColumn _column in toConvert.Columns)
            {
                _genericObject.Properties.Add(new GenericProperty(_column.ColumnName,_row[_column]));
            }
            _result.Add(_genericObject);
        }
        return _result;
    }
