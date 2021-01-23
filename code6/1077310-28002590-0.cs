    [TestMethod]
    public void Executable_Process_Is_Thread_Safe()
    {
       const string executablePath = "Thread.Locking.exe";
            for (var i = 0; i < 1000; i++) {
                var process = new Process() {StartInfo = {FileName = executablePath}};
                process.Start();
                process.WaitForExit();
                if (process.ExitCode == 1) {
                    Assert.Fail();
                }
            }
    }
**When I ran the unit test, it seemed that the Parallel.For execution in Program.cs threw strange exceptions at times, so I had to change that to traditional for-loops:**
