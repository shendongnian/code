    var jsonFile = Server.MapPath("~/App_Data/favecolors.json");
    FileStream fs = new FileStream(@jsonFile, FileMode.Open, FileAccess.ReadWrite);
    fs.SetLength(fs.Length - 1); // Remove the last symbol ']'
    fs.Close();
    string json = JsonConvert.SerializeObject(favecolors, Formatting.Indented);
    System.IO.File.AppendAllText(@jsonFile, "," + json + "]");
