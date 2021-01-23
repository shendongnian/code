    //Instantiate the reader, providing the list of columns which matches 1 to 1 the data table structure.
    var dataReader = new CsvDataReader(filePath,
        new List<TypeCode>(5)
        {
            TypeCode.String,
            TypeCode.Decimal,
            TypeCode.String,
            TypeCode.Boolean,
            TypeCode.DateTime
        });
    bulkCopyUtility.BulkCopy("TableName", dataReader);
