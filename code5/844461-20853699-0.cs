    public void UploadFile(string columnName, string filePath)
    {
        // create new field with columnName
        var index = GetColumnIndex(columnName);
        CreateNewField(index, columnName);
        // change field type to file
        Columns[index].ColumnType = FieldType.file;
        // Get field location with column index
        var fieldIndex = _fields.IndexOf(new QField(Columns[index].ColumnId));
        SetExistingField(index, fieldIndex, filePath);
    }
