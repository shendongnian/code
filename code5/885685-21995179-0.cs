    // store this somewhere (a static field?)
    var columnTypeToCellDataTypeMap = new Dictionary<Type, CellValues>
        {
            { typeof(Boolean), CellValues.Boolean },
            { typeof(Byte), CellValues.Number },
            { typeof(Decimal), CellValues.Number },
            { typeof(Char), CellValues.String },
            { typeof(DateTime), CellValues.Date },
            { typeof(Double), CellValues.Number },
            { typeof(Decimal), CellValues.Number },
            { typeof(Int16), CellValues.Number },
            { typeof(Int32), CellValues.Number },
            { typeof(Int64), CellValues.Number },
            { typeof(SByte), CellValues.Number },
            { typeof(Single), CellValues.Number },
            { typeof(String), CellValues.String },
            { typeof(UInt16), CellValues.Number },
            { typeof(UInt32), CellValues.Number },
            { typeof(UInt64), CellValues.Number },
        }
    // and use it like this:
    foreach (DataRow row in table.Rows)
    {
        foreach (DataColumn column in table.Columns)
        {
            // map the column type to an OpenXML SDK CellValues type
            CellValues cellDataType;
            if (!columnTypeToCellDataTypeMap.TryGetValue(column.DataType, out cellDataType))
                cellDataType = CellValues.String;
            // get the cell value
            object value = row[column];
            string cellValue = (value != null ? value.ToString() : "");
            // construct the cell
            var cell = new Cell { DataType = cellDataType, CellValue = value };
            // etc
            ...
        }
    }
