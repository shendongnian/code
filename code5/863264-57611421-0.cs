    // C#
    var pKeys = new DataColumn[2]; // array
    pKeys[0] = dt.Columns[dt.Columns.IndexOf("<first column name goes here>")]; // column 0-based of the table of interest
    // if multi-part
    pKeys[1] = dt.Columns[dt.Columns.IndexOf("<second column name goes here>")]; // column 0-based of the table of interest
    ...
    ...
    dt.PrimaryKey = pKeys;
