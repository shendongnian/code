        public static void Kill()
        {
            int processId = GetProcessIdByServiceName(ServiceName);
         
            var process = Process.GetProcessById(processId);
            process.Kill();
        }
        private static int GetProcessIdByServiceName(string serviceName)
        {
            string qry = $"SELECT PROCESSID FROM WIN32_SERVICE WHERE NAME = '{serviceName }'";
            var searcher = new ManagementObjectSearcher(qry);
            var managementObjects = new ManagementObjectSearcher(qry).Get();
            if (managementObjects.Count != 1)
                throw new InvalidOperationException($"In attempt to kill a service '{serviceName}', expected to find one process for service but found {managementObjects.Count}.");
            int processId = 0;
            foreach (ManagementObject mngntObj in managementObjects)
                processId = (int)(uint) mngntObj["PROCESSID"];
            if (processId == 0)
                throw new InvalidOperationException($"In attempt to kill a service '{serviceName}', process ID for service is 0. Possible reason is the service is already stopped.");
            return processId;
        }
