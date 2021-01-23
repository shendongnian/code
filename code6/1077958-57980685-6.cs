            Process process = Process.GetCurrentProcess();
            var fieldInfo = typeof(Process).GetField("haveProcessHandle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var v1 = fieldInfo.GetValue(process);
            var processName = process.ProcessName;
            var v2 = fieldInfo.GetValue(process);
            var processHandle = process.Handle;
            var v3 = fieldInfo.GetValue(process);
