    /* Gives you an array of file names */
    string[] filePaths = Directory.GetFiles(@"C:\Users\IT-Administrator\Desktop\LUVS/", "*.xml", SearchOption.AllDirectories); 
    /* You aren't using the array, but instead just trying to open a wildcard path. */
    /* You can't do that. */
    FileStream stream = File.Open(@"C:\Users\IT-Administrator\Desktop\LUVS*.xml", 
    FileMode.Open); 
    ....
    tblVehicles = new DataTable(); 
    dv = new DataView(tblVehicles); 
    tblVehicles.ReadXmlSchema(Path.Combine(applicationFolder, "vehicles_in.xsd")); 
    tblVehicles.ReadXml(stream);
