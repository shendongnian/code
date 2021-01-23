    using System;
    using System.IO;
    using Gallio.Runner;
    using Gallio.Runtime;
    using Gallio.Runtime.Logging;
    using MbUnit.Framework;
    public static class Program
    {
        public static void Main()
        {
            using (TextWriter tw = new StreamWriter("RunTests.log"))
            {
                var logger = new TextLogger(tw);
                RuntimeBootstrap.Initialize(new RuntimeSetup(), logger);
                TestLauncher launcher = new TestLauncher();
                launcher.AddFilePattern("RunTests.exe");
                TestLauncherResult result = launcher.Run();
                Console.WriteLine(result.ResultSummary);
            }
        }
    }
    public class Tests
    {
        [Test]
        public void Pass()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void Fail()
        {
            Assert.Fail();
        }
    }
