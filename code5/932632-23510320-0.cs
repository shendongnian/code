    try
            {
                Process[] javaProcList = Process.GetProcessesByName("java");
                foreach (Process javaProc in javaProcList)
                {
                    javaProc.Kill();
                    javaProc.Close();
                    javaProc.Dispose();
    
                    Console.WriteLine("StopJar -Java Process Stopped ");
                    log.Debug("StopJar -Java Process Stopped ");
                }
            }
            catch (Exception exp)
            {
                log.Error("StopJar - Unable to kill Java Process", exp);
                Console.WriteLine("Error while closing: " + exp.Message);
            }
