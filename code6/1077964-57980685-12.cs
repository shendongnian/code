            Process process = Process.GetCurrentProcess();
            var fieldInfo = typeof(Process).GetField("haveProcessHandle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var v1 = fieldInfo.GetValue(process);
            //v1 is false. Explicit Dispose is not necessary.
            var processName = process.ProcessName;
            var v2 = fieldInfo.GetValue(process);
            //v2 is false. Explicit Dispose is not necessary.
            var processHandle = process.Handle;
            var v3 = fieldInfo.GetValue(process);
            //v3 is true. Bah. Explicit Dispose IS necessary from now on.
