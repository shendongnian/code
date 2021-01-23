    string execId = null;
    string className = null;
    string testName = null;
    string testResult = null;
    string resultLine = null;
    List<string> results = new List<string>();
    XmlDocument resultsDoc = new XmlDocument();
    XmlNode executionNode = null;
    XmlNode testMethodNode = null;
    // Define the test instance settings
    Process testInstance = null;
    ProcessStartInfo testInfo = new ProcessStartInfo()
    {
        UseShellExecute = false,
        CreateNoWindow = true,
    };
    // Fetch project list from the disk
    List<string> excluded = ConfigurationManager.AppSettings["ExcludedProjects"].Split(',').ToList();
    DirectoryInfo assemblyPath = new DirectoryInfo(Assembly.GetExecutingAssembly().Location);
    DirectoryInfo[] directories = assemblyPath.Parent.Parent.Parent.Parent.GetDirectories();
    // Create a test worklist
    List<string> worklist = directories.Where(t => !excluded.Contains(t.Name))
                                        .Select(t => String.Format(ConfigurationManager.AppSettings["MSTestCommand"], t.FullName, t.Name))
                                        .ToList();
    // Start test execution
    Console.WriteLine("Starting Execution...");
    Console.WriteLine();
    Console.WriteLine("Results               Top Level Tests");
    Console.WriteLine("-------               ---------------");
    // Remove any existing run results
    if (File.Exists("UnitTests.trx"))
    {
        File.Delete("UnitTests.trx");
    }
    // Run each project in the worklist
    foreach (string item in worklist)
    {
        testInfo.FileName = item;
        testInstance = Process.Start(testInfo);
        testInstance.WaitForExit();
        if (File.Exists("UnitTests.trx"))
        {
            resultsDoc = new XmlDocument();
            resultsDoc.Load("UnitTests.trx");
            foreach (XmlNode result in resultsDoc.GetElementsByTagName("UnitTestResult"))
            {
                // Get the execution ID for the test
                execId = result.Attributes["executionId"].Value;
                // Find the execution and test method nodes
                executionNode = resultsDoc.GetElementsByTagName("Execution")
                                            .OfType<XmlNode>()
                                            .Where(n => n.Attributes["id"] != null && n.Attributes["id"].Value.Equals(execId))
                                            .First();
                testMethodNode = executionNode.ParentNode
                                                .ChildNodes
                                                .OfType<XmlNode>()
                                                .Where(n => n.Name.Equals("TestMethod"))
                                                .First();
                // Get the class name, test name and result
                className = testMethodNode.Attributes["className"].Value.Split(',')[0];
                testName = result.Attributes["testName"].Value;
                testResult = result.Attributes["outcome"].Value;
                resultLine = String.Format("{0}                {1}.{2}", testResult, className, testName);
                results.Add(resultLine);
                Console.WriteLine(resultLine);
            }
            File.Delete("UnitTests.trx");
        }
    }
    // Calculate passed / failed test case count
    int passed = results.Where(r => r.StartsWith("Passed")).Count();
    int failed = results.Where(r => r.StartsWith("Failed")).Count();
    // Print the summary
    Console.WriteLine();
    Console.WriteLine("Summary");
    Console.WriteLine("-------");
    Console.WriteLine("Test Run {0}", failed > 0 ? "Failed." : "Passed.");
    Console.WriteLine();
    if (passed > 0)
        Console.WriteLine("\tPassed {0,7}", passed);
    if (failed > 0)
        Console.WriteLine("\tFailed {0,7}", failed);
    Console.WriteLine("\t--------------");
    Console.WriteLine("\tTotal {0,8}", results.Count);
    if (failed > 0)
        Environment.Exit(-1);
    else
        Environment.Exit(0);
