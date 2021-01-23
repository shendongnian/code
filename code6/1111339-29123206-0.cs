    ProcessStartInfo psi = new ProcessStartInfo()
    {
        FileName = "cmd.exe",
        WindowStyle = ProcessWindowStyle.Hidden,
        UseShellExecute = false,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        CreateNoWindow = true,
    };
    Process p = new Process();
    p.StartInfo = psi;
    p.Start();
    // Output handling:
    p.OutputDataReceived += (o, e) => Console.WriteLine(e.Data);
    p.BeginOutputReadLine();
    var reposToUpdate = ConfigurationManager.AppSettings["UpdateAndMergeReposOnBranch"];
    foreach (XmlNode repoPathNode in reposPaths)
    {
        var repoPath = repoPathNode.Attributes["root"].Value;
        p.StandardInput.WriteLine(string.Format("cd {0}", repoPath));
        p.StandardInput.WriteLine(@"hg update --check");
        p.StandardInput.Flush();
    }
    p.StandardInput.Close();
