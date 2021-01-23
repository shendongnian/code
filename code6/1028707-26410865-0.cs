    using Microsoft.Azure.WebJobs;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Newtonsoft.Json;
    using Proceed.Common;
    using System;
    using System.Configuration;
    using System.IO;
    
    public class WebJobsTask {
      public static void Main()
      {
          JobHost host = new JobHost();
          host.RunAndBlock();
      }
    
      public static void CreateLeague([QueueTrigger("temp")] string msg)
      {
        var task = JsonConvert.DeserializeObject<QueueTask>(msg);
    
        if (task.TaskType == QueueTask.TaskTypes.Pdf)
          RenderPdf(task.Id);
      }
    }
