    // Read the 'PageSettings' column from the ASP personalization tables
    // into a byte array variable called 'rawData' first. Then continue:
    var mems = new System.IO.MemoryStream(rawData);
    var formatter = new System.Web.UI.ObjectStateFormatter();
    var oldState = formatter.Deserialize(mems) as object[];
    var index = oldState.ToList()
                        .FindIndex(o =>
                            o as Type != null &&
                            ((Type)o).Name.Contains("WebPartManager"));
    // In our case, the derivative class name is "MyWebPartManager", you
    // may need to change that to meet your requirements
    oldState[index] = typeof(WebPartManager);
    mems = new System.IO.MemoryStream();
    formatter.Serialize(mems, oldState);
    var newState = mems.ToArray();
    // Write 'newState' back into the database.
