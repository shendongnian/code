     private DateTime GetLastDocumentRun(string documentName)
        {
            string QMS = "http://MyQlikviewserver:4799/QMS/Service";
            var client = new QMSClient("BasicHttpBinding_IQMS", QMS);
            string key = client.GetTimeLimitedServiceKey();
            ServiceKeyClientMessageInspector.ServiceKey = key;
            var taskStatusFilter = new TaskStatusFilter();
            var clientTaskStatuses = client.GetTaskStatuses(taskStatusFilter, TaskStatusScope.All);
            foreach (var taskStatus in clientTaskStatuses)
            {
                Trace.WriteLine(taskStatus.General.TaskName);
                if (taskStatus.General.TaskName.ToLower().Contains(documentName.ToLower()))
                {
                    string fin = taskStatus.Extended.FinishedTime + "";
                    DateTime finishedTime;
                    if (DateTime.TryParse(fin, out finishedTime))
                        return finishedTime;
                   Logger.ErrMessage("QvManagementApi.GetLastDocumentRun",new Exception("Task finished time did not return a valid datetime value:" + fin));
                   return DateTime.MinValue;
                }
            }
            return DateTime.MinValue;
        }
