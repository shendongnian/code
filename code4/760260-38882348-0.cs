    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Threading;
    public static string runCommand(string cpath, string[] args)
    {
    	using (var p = new Process())
    	{
    		// notice that we're using the Windows shell here and the unix-y 2>&1
    		p.StartInfo.FileName = @"c:\windows\system32\cmd.exe";
    		p.StartInfo.Arguments = "/c \"" + cpath + " " + String.Join(" ", args) + "\" 2>&1";
    		p.StartInfo.UseShellExecute = false;
    		p.StartInfo.RedirectStandardOutput = true;
    		p.StartInfo.RedirectStandardError = true;
    		var output = new StringBuilder();
    		using (var outputWaitHandle = new AutoResetEvent(false))
    		{
    			p.OutputDataReceived += (sender, e) =>
    			{
    				// attach event handler
    				if (e.Data == null)
    				{
    					outputWaitHandle.Set();
    				}
    				else
    				{
    					output.AppendLine(e.Data);
    				}
    			};
    			// start process
    			p.Start();
    			// begin async read
    			p.BeginOutputReadLine();
    			// wait for process to terminate
    			p.WaitForExit();
    			// wait on handle
    			if (outputWaitHandle.WaitOne())
    			{
    				// check exit code
    				if (p.ExitCode == 0)
    				{
    					var retval = output.ToString();
    					return retval;
    				}
    				else
    				{
    					throw new Exception("Something bad happened");
    				}
    			}
    			else
    			{
    				throw new Exception("Never actually get here");
    			}
    		}
    	}
    }
