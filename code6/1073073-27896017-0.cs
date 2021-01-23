    // Example use
    RunTest(@"..\..\..\UnitTestProject1\bin\Debug\UnitTestProject1.dll", "UnitTest1.TestMethod2", "out2.trx");
    private static void RunTest(string testDll, string testMethod, string outFile)
    {
        //Contract.Requires(!String.IsNullOrEmpty(testDll));
        //Contract.Requires(!String.IsNullOrEmpty(testMethod));
        //Contract.Requires(!String.IsNullOrEmpty(outFile));
        testDll = Path.GetFullPath(testDll);
        // this and all of the other tests suffer from TOCTOU issues, but they
        // are just advisory.  MSTest is the real gauntlet.
        if (!File.Exists(testDll))
        {
            throw new FileNotFoundException("testDll not found", testDll);
        }
        outFile = Path.GetFullPath(outFile);
        if (File.Exists(outFile) || !Directory.Exists(Path.GetDirectoryName(outFile)))
        {
            throw new InvalidOperationException("outFile already exists or directory does not exist");
        }
        string msTestLoc = GetMsTestPath("12.0"); // 12 == 2013, 11 = 2012, 10 == 2010, 9 == 2008
        // while testDll and outFile are minimally validated, testMethod is a
        // ripe target for injection into the command arguments.  Validation
        // would be appropriate.
        var psi = new ProcessStartInfo(msTestLoc, string.Format(
            "/testcontainer:\"{0}\" /test:{1} /unique /resultsfile:\"{2}\"",
            testDll, testMethod, outFile))
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardError = true,
            RedirectStandardOutput = true
        };
        var proc = Process.Start(psi);
        var errorOutput = new StringBuilder();
        proc.ErrorDataReceived += (_1, args) => errorOutput.AppendLine(args.Data);
        proc.OutputDataReceived += (_1, args) => errorOutput.AppendLine(args.Data);
        proc.BeginErrorReadLine();
        proc.BeginOutputReadLine();
        proc.WaitForExit();
        // we would check the return code here, but they don't seem to be documented
        if (!File.Exists(outFile))
        {
            throw new InvalidOperationException("mstest.exe did not produce an "
                + "output file:\r\n" + errorOutput.ToString());
        }
    }
    private static string GetMsTestPath(string vsVersion)
    {
        //Contract.Ensures(Contract.Result<string>() != null);
        //Contract.Requires(!string.IsNullOrEmpty(vsVersion));
        using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
        using (var vsReg = hklm.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\VisualStudio\" + vsVersion))
        {
            var res = (string)vsReg.GetValue("InstallDir");
            if (res == null || !Directory.Exists(res))
            {
                throw new InvalidOperationException("VS install path not found");
            }
            var msbuildPath = Path.Combine(res, "mstest.exe");
            if (!File.Exists(msbuildPath))
            {
                throw new InvalidOperationException("MSTest not found");
            }
            return msbuildPath;
        }
    }
