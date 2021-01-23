    using System.IO;
    using System.Diagnostics;
    var filesList = Directory.GetFiles(folder, "*.tif");
    var bioformats = "Bio-Formats Importer";
    foreach(var fileName in filesList)  // loop through every file
    {
        var options = string.Format("open=[{0}] display_ome-xml", fileName.Replace("\\", "\\\\"));
        var args = string.Format("-eval run(\"'{0}'\",\"'{1}'\")", bioformats, options);
        try
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = fijiExeFile,
                    Arguments = args,
                }
            };
            process.Start();
            process.WaitForExit();
            ret = 1;
        }
        catch (Exception ex)
        {
            ex.ToString();
            ret = 0;
        }
    }
