    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using Xunit;
    
    namespace UnitTests.Persistence
    {
        public class AzureStorageEmulatorManagerV3
        {
            private const string ProcessName = "WAStorageEmulator";
    
            public static void StartStorageEmulator()
            {
                var count = Process.GetProcessesByName(ProcessName).Length;
                if (count == 0)
                    ExecuteWAStorageEmulator("start");
            }
    
            public static void StopStorageEmulator()
            {
                Process process = GetWAstorageEmulatorProcess();
                if (process != null)
                {
                    process.Kill();
                }
            }
    
            private static void ExecuteWAStorageEmulator(string argument)
            {
                var start = new ProcessStartInfo
                {
                    Arguments = argument,
                    FileName = @"c:\Program Files (x86)\Microsoft SDKs\Windows Azure\Storage Emulator\WAStorageEmulator.exe"
                };
                var exitCode = ExecuteProcess(start);
                if (exitCode != 0)
                { 
                    string message = string.Format(
                        "Error {0} executing {1} {2}",
                        exitCode,
                        start.FileName,
                        start.Arguments);
                    throw new InvalidOperationException(message);
                }
            }
    
            private static int ExecuteProcess(ProcessStartInfo start)
            {
                int exitCode;
                using (var proc = new Process { StartInfo = start })
                {
                    proc.Start();
                    proc.WaitForExit();
                    exitCode = proc.ExitCode;
                }
                return exitCode;
            }
    
            public static Process GetWAstorageEmulatorProcess()
            {
                return Process.GetProcessesByName(ProcessName).FirstOrDefault();
            }
    
            [Fact]
            public void StartingAndThenStoppingWAStorageEmulatorGoesOk()
            {
                // Arrange Start
                AzureStorageEmulatorManagerV3.StartStorageEmulator();
                
                // Act 
                Thread.Sleep(2000);
                Process WAStorageEmulatorProcess = GetWAstorageEmulatorProcess();
    
                // Assert 
                Assert.NotNull(WAStorageEmulatorProcess);
                Assert.True(WAStorageEmulatorProcess.Responding);
    
                // Arrange Stop
                AzureStorageEmulatorManagerV3.StopStorageEmulator();
                Thread.Sleep(2000);
                // Act
                WAStorageEmulatorProcess = GetWAstorageEmulatorProcess();
    
                // Assert 
                Assert.Null(WAStorageEmulatorProcess);
            }
        }
    }
