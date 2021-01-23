    Process process = new Process();
    
    process.StartInfo.CreateNoWindow = false;
    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
    process.StartInfo.FileName = @"C:\c#\Work\RulesValidator\RulesValidator\Asset_Id.py";
    try
    {
        process.Start();
        process.WaitForExit(); // Now child should have done its job and closed file
    }
    catch (Exception ex)
    {
        System.Console.WriteLine(ex.Message);
    }
    asset_id.Text = System.IO.File.ReadAllText(@"C:\c#\Work\RulesValidator\RulesValidator\Asset_Id.txt");
