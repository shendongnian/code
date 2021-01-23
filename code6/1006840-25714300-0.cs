    string[] columns = {"COL1","COL2","COL3","COL4","COL5"};
    var rows = source.Skip(1)
                     .Select(c => columns.Zip(c.Split(','),
                                              (column, value) => new
                                                                 {
                                                                     Column = column,
                                                                     Value = value
                                                                 });
    
    var elements = rows.Select(c => new XElement("Records",
                                                 c.Select(x => new XElement(c.Column, c.Value))));
    
    return new XElement("Root", elements);
