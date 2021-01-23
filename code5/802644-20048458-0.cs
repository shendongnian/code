    string f1 = @"file1.cs";
    string f2 = @"f2.cs";
    Microsoft.TeamFoundation.VersionControl.Common.DiffOptions options = new Microsoft.TeamFoundation.VersionControl.Common.DiffOptions();
    options.Recursive = true;
    options.StreamWriter = new System.IO.StreamWriter(Console.OpenStandardOutput());
    options.UseThirdPartyTool = true;
    options.OutputType = Microsoft.TeamFoundation.VersionControl.Common.DiffOutputType.Unified;            
    var diff = Difference.DiffFiles(
                f1, FileType.Detect(f1, null),
                f2, FileType.Detect(f2, null),
                options);
    while (diff != null)
    {
        // Do whatever it is that you want to do here            
        diff = diff.Next;
    }
