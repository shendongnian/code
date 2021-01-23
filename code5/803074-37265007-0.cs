    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    //Include a reference to system
    
    class MyClass {
      static void Main() {
        InitiateSelfDestructSequence();
        Thread.Sleep(10000);
      }
      static void InitiateSelfDestructSequence() {
        string batchScriptName = "BatchScript.bat";
        using (StreamWriter writer = File.AppendText(batchScriptName)) {
          writer.WriteLine(":Loop");
          writer.WriteLine("Tasklist /fi \"PID eq " + Process.GetCurrentProcess().Id.ToString() + "\" | find \":\"");
          writer.WriteLine("if Errorlevel 1 (");
          writer.WriteLine("  Timeout /T 1 /Nobreak");
          writer.WriteLine("  Goto Loop");
          writer.WriteLine(")");
          writer.WriteLine("Del \"" + (new FileInfo((new Uri(Assembly.GetExecutingAssembly().CodeBase)).LocalPath)).Name + "\"");
        }
        Process.Start(new ProcessStartInfo() { Arguments = "/C " + batchScriptName + " & Del " + batchScriptName, WindowStyle = ProcessWindowStyle.Hidden, CreateNoWindow = true, FileName = "cmd.exe" });
      }
    }
