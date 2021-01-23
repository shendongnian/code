    // Prepare the directory and file names
    var directoryName = "C:\\Temp\\MyFolder";
    var filenames = new List<string>();
    filenames.Add("0001.jpg");
    filenames.Add("2345.jpg");
    // Construct FileInfo array - using System.IO
    var files = new FileInfo[filenames.Count];
    for (var i = 0; i < filenames.Count; i++)
    {
        var fileName = filenames[i];
        files[i] = new FileInfo(Path.Combine(directoryName, fileName));
    }
