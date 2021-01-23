    // loading xml for grid
    XmlDocument doc = new XmlDocument();
    doc.Load(_file_location_); // (it does find the xml)
    
    // setting the xml provider
    XmlDataProvider _xmlDataProvider = new XmlDataProvider();
    _xmlDataProvider.Document = doc;
    _xmlDataProvider.XPath = @"/ShipData/Draught/Sensor";
    
    // Setting the datacontext (updated code)
    Binding binding = new Binding();
    binding.Source = _xmlDataProvider;
    MDataGrid.SetBinding(DataGrid.ItemsSourceProperty, binding);
    
    // Creating the column Sensor (as an example) and create a new binding for xpath
    var dataGridTextColumn = new DataGridTextColumn();
    
    Binding bindingSensor = new Binding();
    bindingSensor.XPath = "@Name";
    dataGridTextColumn.Binding = bindingSensor;
    dataGridTextColumn.Header = "Sensor";
    
    // other repeating columns (bis+man ...) omitted for this example
    
    // adding the column to the datagrid
    MDataGrid.Columns.Add(dataGridTextColumn);
